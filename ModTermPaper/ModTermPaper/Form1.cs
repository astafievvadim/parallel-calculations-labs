using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ModTermPaper
{
    public partial class Form1 : Form
    {

        UInt16 A;        // 16 бит
        UInt32 B;        // 17 бит (храним в 32 битах, но младшие 17 значимы)
        UInt32 C;        // 17 бит (также в 32 битах)
        byte CT;         // 4 бит
        bool PP;         // признак переполнения

        UInt16 tmpA;                //промежуточные результаты А
        UInt32 tmpB;                //промежуточные результаты B
        UInt32 tmpC;                //промежуточные результаты деления

        byte a;                     //текущее состояние

        bool[] D, Q;                //множество D и Q сигналов
        bool[] y, x;                //вектор y и x сигналов
        bool[] PLU;                 //память логических условий
        bool[] A_out;               //состояние во время такта

        DataGridView[] dgvArray;    //массив регистров

        bool run = true;            //значение выполнения   
        bool isRead = false;        //флаг запуска

        // Конструктор
        public Form1()
        {
            InitializeComponent();
            dgvArray = new[] { dgvA, dgvB, dgvRgC, dgvRgCr};
            run = false;
            a = 0;
            Q = new bool[2];
            D = new bool[2];
            A_out = new bool[4];
            y = new bool[14];
            x = new bool[7];
            PLU = new bool[1];

            showA();
        }

        #region Отображение значений

        // Отображение в DataGridView значения valX
        private void setDgvs(DataGridView dgvX, UInt32 valX)
        {
            UInt32 saveValX = valX;

            // Common routine for all dgv
            for (int col = dgvX.ColumnCount - 1; col >= 0; col--)
            {
                dgvX[col, 0].Value = (valX & 1);
                valX >>= 1;
            }

            // Special textbox update for dgvRgC only
            if (dgvX.Name == "dgvRgC")
            {
                fillTBbyValue(txBxC, saveValX);
            }
        }

        // Получение десятичного значения числа, записанного в DataGridView
        private UInt32 getValue(DataGridView dtGridX)
        {
            UInt32 res = 0;
            int bitsCount = dtGridX.ColumnCount;

            for (int col = 0; col < bitsCount; col++)
            {
                var cellValue = dtGridX[col, 0].Value;
                if (cellValue == null) continue;

                if (UInt32.TryParse(cellValue.ToString(), out UInt32 bit))
                {
                    if (bit == 1)
                    {
                        res |= (1u << (bitsCount - col - 1));
                    }
                }
            }
            return res;
        }

        // Запись числа в TextBox с учетом знака и битовой структуры ваших регистров
        private void fillTBbyValue(TextBox txBxX, UInt32 valX)
        {
            double res = 0;

            if (txBxX.Name == "txBxC")
            {
                // Работаем с 30-битным числом, знаковый бит в позиции 30 (0-based)
                const int bitLen = 30;

                bool isNegative = ((valX >> bitLen) & 1) == 1;

                UInt32 mask = (1u << bitLen) - 1;
                UInt32 magnitude = valX & mask;

                for (int pow = bitLen - 1; pow >= 0; pow--)
                {
                    if ((magnitude & (1u << pow)) != 0)
                    {
                        res += Math.Pow(2, pow - bitLen);
                    }
                }

                if (isNegative)
                    res = -res;

                res = Math.Round(res, 10);
                txBxX.Text = res.ToString("0.##########");
            }
            else if (txBxX.Name == "txBxB")
            {
                // Для A: 16-битное знаковое число, знак в позиции 16 (0-based)
                const int bitLen = 16;

                bool isNegative = ((valX >> bitLen) & 1) == 1;

                UInt32 mask = (1u << bitLen) - 1;
                UInt32 magnitude = valX & mask;

                for (int pow = bitLen - 1; pow >= 0; pow--)
                {
                    if ((magnitude & (1u << pow)) != 0)
                    {
                        res += Math.Pow(2, pow - bitLen);
                    }
                }

                if (isNegative)
                    res = -res;

                res = Math.Round(res, 5);
                txBxX.Text = res.ToString("0.#####");
            }
            else
            {
                // Для B, AM и других: 15 бит знаковых чисел, знак на 15-й позиции (0-based)
                const int bitLen = 15;

                bool isNegative = ((valX >> bitLen) & 1) == 1;

                UInt32 mask = (1u << bitLen) - 1;
                UInt32 magnitude = valX & mask;

                for (int pow = bitLen - 1; pow >= 0; pow--)
                {
                    if ((magnitude & (1u << pow)) != 0)
                    {
                        res += Math.Pow(2, pow - bitLen);
                    }
                }

                if (isNegative)
                    res = -res;

                res = Math.Round(res, 5);
                txBxX.Text = res.ToString("0.#####");
            }
        }


        // Изменение значения ячейки исходных данных по клику
        private void dtGridSource_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                var dgv = sender as DataGridView;
                var cell = dgv[e.ColumnIndex, e.RowIndex];

                cell.Value = cell.Value?.ToString() == "0" ? "1" : "0";

                // Обновляем значение в текстбоксе согласно изменению
                if (dgv.Name == "dgvA")
                {
                    UInt32 val = getValue(dgv);
                    fillTBbyValue(txBxA, val);

                    // Обработка знака: если старший бит == 1 и не ноль, добавляем '-'
                    if (dgv[0, 0].Value?.ToString() == "1" && txBxA.Text != "0")
                        txBxA.Text = "-" + txBxA.Text;
                }
                else if (dgv.Name == "dgvB")
                {
                    UInt32 val = getValue(dgv);
                    fillTBbyValue(txBxB, val);

                    if (dgv[0, 0].Value?.ToString() == "1" && txBxB.Text != "0")
                        txBxB.Text = "-" + txBxB.Text;
                }
            }
        }

        #endregion

        #region расчет Y

        private UInt32 y0()
        {
            // Выполнено
            // Возвращаем 0 для логики завершения
            return 0;
        }

        private UInt32 y1()
        {
            // C := A(14:0)
            // Копируем младшие 15 бит A в младшие 15 бит C, старший бит C обнуляем
            // По разрядной сетке C 17 бит, тут 0..14, 15,16 — старшие
            // По таблице младшие 15 бит A (0..14)
            UInt32 res = (uint)(A & 0x7FFF); // 15 бит
            return res; // старшие биты C обнулены
        }

        private UInt32 y2()
        {
            // A(14:0) := B(14:0)
            // Берём младшие 15 бит B (0..14) и записываем в A (16 бит)
            return (UInt32)(B & 0x7FFF);
        }

        private UInt32 y3()
        {
            // C := C + 11 * A̅(14:0) + 1
            // A̅ — инверсия младших 15 бит A (0..14)
            UInt16 A_inverted = (UInt16)(~A & 0x7FFF);
            UInt32 addend = (UInt32)(11 * A_inverted + 1);

            UInt32 result = C + addend;

            // Обрезаем до 17 бит (0..16)
            result &= 0x1FFFF;

            return result;
        }

        private UInt32 y4()
        {
            // C := C + A(14:0)
            UInt32 result = C + (uint)(A & 0x7FFF);

            // Обрезаем до 17 бит
            result &= 0x1FFFF;

            return result;
        }

        private UInt16 y5()
        {
            // ПП := 1 (признак переполнения)
            PP = true;
            return 1; // возвращаем 1 для сохранения в tmpAM, если надо
        }

        private UInt32 y6()
        {
            // C := L1(C.0)
            // Логический сдвиг влево C на 1 бит, младший бит = 0
            UInt32 shifted = (C << 1) & 0x1FFFF; // маска 17 бит
            return shifted;
        }

        private UInt32 y7()
        {
            // СЧ := 0
            CT = 0;
            return 0;
        }

        private UInt32 y8()
        {
            // B(15:0) := 0
            tmpB = 0; // очищаем tmpB
            return 0;
        }

        private UInt32 y9()
        {
            // B(15:0) := L1(B(15:0).C̅(16))
            // Сдвиг B влево на 1 бит, в младший бит вставляем инверсию старшего бита C (16-й бит)
            int cBit16 = (int)((C >> 16) & 1);
            int insertBit = cBit16 == 0 ? 1 : 0;

            UInt32 shiftedB = ((B << 1) & 0x1FFFF) | (UInt32)insertBit;
            return shiftedB;
        }

        private UInt32 y10()
        {
            // СЧ := СЧ - 1
            if (CT > 0)
                CT--;
            return 0;
        }

        private UInt32 y11()
        {
            // C := B(15:0)
            UInt32 res = B & 0xFFFF; // младшие 16 бит
            return res;
        }

        private UInt32 y12()
        {
            // C(16:1) := C(16:1) + 1
            // Прибавляем 1 к битам 1..16, младший бит (0) не трогаем

            UInt32 upperBits = (C >> 1) & 0xFFFF; // 16 бит сдвинуты вправо, 1..16
            upperBits = (upperBits + 1) & 0xFFFF; // +1 по 16 битам
            UInt32 newC = (upperBits << 1) | (C & 1); // младший бит C остаётся без изменений
            newC &= 0x1FFFF; // 17 бит маска
            return newC;
        }

        private UInt32 y13()
        {
            // C(16) := 1 — установить старший бит (16-й индекс) C
            return C | (1u << 16);
        }

        #endregion

        #region расчет Х
        private bool x0()
        {
            // Пуск (RUN)
            return run;
        }

        private bool x1()
        {
            // A(14:0) == 0 — младшие 15 бит A
            return (A & 0x7FFF) == 0;
        }

        private bool x2()
        {
            // C == 0 — все 17 бит
            return (C & 0x1FFFF) == 0;
        }

        private bool x3()
        {
            // C(16) == 1 — старший бит C, бит с индексом 16 (0-based)
            return ((C >> 16) & 1) == 1;
        }

        private bool x4()
        {
            // СЧ == 0 — счётчик циклов
            return CT == 0;
        }

        private bool x5()
        {
            // B(0) == 1 — младший бит B
            return (B & 1) == 1;
        }

        private bool x6()
        {
            // A(15) + B(16) == 1 (XOR)
            int bitA15 = (A >> 15) & 1;
            int bitB16 = (int)((B >> 16) & 1);
            return (bitA15 ^ bitB16) == 1;
        }

        #endregion

        #region Вывод на форму

        // Установка состояний
        private void showA()
        {
            bool[] A_out1 = new bool[8];
            for (byte el = 0; el < A_out1.Length; el++) A_out1[el] = false;
            A_out1[a] = true;

            chkBxMPa0.Checked = A_out1[0];
            chkBxMPa1.Checked = A_out1[1];
            chkBxMPa2.Checked = A_out1[2];
            chkBxMPa3.Checked = A_out1[3];
        }
        #endregion

        #region Взаимодействие УА и ОА

        // Память состояний
        private void stateMem()
        {
            D.CopyTo(Q, 0);
        }

        // Дешифратор 
        private void DC()
        {
            // Reset previous A_out
            for (int i = 0; i < A_out.Length; i++)
                A_out[i] = false;

            a = 0;
            if (Q[0]) a += 1;
            if (Q[1]) a += 2;

            A_out[a] = true;
        }

        // Память логических условий
        private void plu()
        {
            // Update all condition flags using your x functions
            x[0] = x0();
            x[1] = x1();
            x[2] = x2();
            x[3] = x3();
            x[4] = x4();
            x[5] = x5();
            x[6] = x6();

            PLU[0] = x[3]; // As per your original logic
        }

        // КС D 
        private void csD()
        {
            D[0] = (A_out[0] && x[0] && !x[1] && !x[2]) || (A_out[2] && x[4] && x[5]);

            D[1] = (A_out[1]) ||
                   (A_out[2] && (!x[4] || x[4]) && PLU[0]) ||
                   (A_out[2] && !x[4] && !PLU[0]) ||
                   (A_out[2] && x[4] && x[5]);
        }

        // КС Y
        private void csY()
        {
            y[0] = (A_out[0] && x[0] && !x[1] && x[2]) ||
                   (A_out[0] && x[0] && x[1]) ||
                   (A_out[0] && x[0] && !x[1] && !x[2]);

            y[1] = y[2] = y[3] = (A_out[0] && x[0] && !x[1] && !x[2]);

            y[4] = y[5] = y[6] = (A_out[1] && PLU[0]) ||
                                 (A_out[1] && !PLU[0]) ||
                                 (A_out[2] && !x[4] && PLU[0]) ||
                                 (A_out[2] && !x[4] && !PLU[0]);

            y[7] = (A_out[1] && PLU[0]) ||
                   (A_out[2] && !x[4] && PLU[0]);

            y[8] = (A_out[2] && x[4] && x[5]);

            y[9] = (A_out[3] && x[6]) ||
                   (A_out[2] && x[4] && !x[5] && x[6]);
        }

        // ОА
        private void OA()
        {
            if (y[0]) tmpC = y0();
            if (y[1]) tmpC = y1(); // C := A(14:0)
            if (y[2]) tmpA = (UInt16)y2(); // A(14:0) := B(14:0)
            if (y[3]) y3();
            if (y[4]) tmpB = (UInt16)y4();
            if (y[5]) { /* ПП:=1 — если нигде не используется, пропустить */ }
            if (y[6]) y6();
            if (y[7]) tmpC = y7();
            if (y[8]) tmpC = y8();
            if (y[9]) tmpC = y9();

            // Update main registers
            A = tmpA;
            B = tmpB;
            C = tmpC;

            // Refresh x conditions after update
            x[0] = x0();
            x[1] = x1();
            x[2] = x2();
            x[3] = x3();
            x[4] = x4();
            x[5] = x5();
            x[6] = x6();
        }

        // Моделирование взаимодействия УА и ОА
        private Boolean runOAUA()
        {
            if (!isEnd() || zeroStep())
                return false;

            plu();
            stateMem();
            DC();
            csY();
            csD();
            OA();

            return true;
        }

        #endregion

        private bool runMP()
        {
            Console.WriteLine($"State a={a}, CT={CT}, A={A}, C={C}, B={B}");

            x[0] = x0();
            x[1] = x1();
            x[2] = x2();
            x[3] = x3();
            x[4] = x4();
            x[5] = x5();
            x[6] = x6();

            switch (a)
            {
                case 0: // a0
                    if (x[0]) // x0 == true -> запуск
                    {
                        tmpC = y1();      // C := A(14:0)
                        tmpA = (UInt16)y2(); // A(14:0) := B(14:0)
                        a = 1;            // переход a0 -> a1
                    }
                    else
                    {
                        run = false;      // Остановка, если пуск не активен
                    }
                    break;

                case 1: // a1
                    if (x[1]) // x1 == true, A(14:0) == 0
                    {
                        y5();           // ПП := 1
                        run = false;
                    }
                    else if (x[2]) // x2 == true, C == 0
                    {
                        a = 2;          // переход a1 -> a2
                    }
                    else
                    {
                        tmpC = y3();    // C := C + 11 * A̅(14:0) + 1
                        a = 3;          // переход a1 -> a3
                    }
                    break;

                case 2: // a2
                    if (x[4]) // x4 == true, СЧ == 0
                    {
                        if (x[5]) // x5 == true, B(0) == 1
                        {
                            tmpB = y8(); // B(15:0) := 0
                        }
                        a = 3;          // переход a2 -> a3
                    }
                    else
                    {
                        a = 1;          // возврат a2 -> a1
                    }
                    break;

                case 3: // a3
                    if (!x[3]) // x3 == false, C(16) == 0
                    {
                        y5();           // ПП := 1
                        run = false;
                    }
                    else
                    {
                        tmpC = y4();    // C := C + A(14:0)
                        a = 4;          // переход a3 -> a4
                    }
                    break;

                case 4: // a4
                    tmpC = y6();      // C := L1(C.0)
                    y7();             // СЧ := 0
                    tmpB = y8();      // B(15:0) := 0
                    a = 5;            // переход a4 -> a5
                    break;

                case 5: // a5
                    tmpC = y3();      // C := C + 11 * A̅(14:0) + 1
                    a = 6;            // переход a5 -> a6
                    break;

                case 6: // a6
                    tmpB = y8();      // B(15:0) := 0
                    a = 7;            // переход a6 -> a7
                    break;

                case 7: // a7
                    if (x[3]) // x3 == true, C(16) == 1
                    {
                        tmpC = y4();  // C := C + A(14:0)
                    }
                    a = 8;            // переход в a8 всегда
                    break;

                case 8: // a8
                    tmpC = y6();      // C := L1(C.0)
                    y10();            // СЧ := СЧ - 1
                    a = 9;            // переход a8 -> a9
                    break;

                case 9: // a9
                    if (x[1]) // x1 == true, A(14:0) == 0
                    {
                        tmpC = y11(); // C := B(15:0)
                        a = 10;       // переход a9 -> a10
                    }
                    else
                    {
                        a = 4;        // возврат a9 -> a4
                    }
                    break;

                case 10: // a10
                    if (x[5]) // x5 == true, B(0) == 1
                    {
                        tmpC = y12(); // C(16:1) := C(16:1) + 1
                        a = 11;       // переход a10 -> a11
                    }
                    else
                    {
                        a = 10;       // остаёмся в a10 (ждем B(0)==1)
                    }
                    break;

                case 11: // a11
                    if (x[6]) // x6 == true, A(15) + B(16) == 1
                    {
                        y13();      // C(16) := 1
                        run = false;
                    }
                    else
                    {
                        a = 11;
                    }
                    break;
            }

            // Отключаем кнопку запуска, если x0 == false (пуск неактивен)
            if (!x[0])
            {
                Старт.Enabled = false;
            }

            return run;
        }



        // Отображение на форме
        private void showForm()
        {
            showA();
            //showQ();
            //showX();
            //showD();
            //showY();
            setDgvs(dgvRgCr, CT);
        }

        // Завершение работы 
        private bool isEnd()
        {
            return !(!D[0] && !D[1] && (Q[0] || Q[1]));
        }

        // a0 переход
        byte count = 0;
        private bool zeroStep()
        {
            if (!D[0] && !D[1]) count++;
            return (!D[0] && !D[1] && !Q[1] && !Q[0]) && (count == 0);
        }

        // Запуск программы
        private void btnStart_Click(object sender, EventArgs e)
        {

            if (!isRead)
            {
                run = true;
                isRead = true;
                A = (UInt16)getValue(dgvA);
                B = (UInt16)getValue(dgvB);

                tmpA = A;
                tmpB = B;

                //chkBxOUx0_mem.Checked = true;

                rdBtnMP.Enabled = false;
                rdBtnOU.Enabled = false;
                dgvA.Enabled = false;
                dgvB.Enabled = false;

                // Initialize all x conditions you want here, or just the ones you use
                x[0] = x0();
                x[1] = x1();
                x[2] = x2();

                showForm();
            }

            if (rdBtnAuto.Checked)
            {
                if (rdBtnMP.Checked)
                {
                    while (runMP()) { }
                    END();
                }
                else
                {
                    while (runOAUA()) { }
                    END();
                }
            }
            else
            {
                if (rdBtnMP.Checked)
                {
                    if (runMP())
                    {
                        showForm();
                    }
                    else
                    {
                        END();
                    }
                }
                else
                {
                    if (runOAUA())
                    {
                        showForm();
                    }
                    else
                    {
                        END();
                    }
                }
            }
        }

        // Сброс
        private void btnStop_Click(object sender, EventArgs e)
        {
            a = 0;
            A = 0;
            B = 0;
            C = 0;

            tmpA = 0;
            tmpB = 0;
            tmpC = 0;

            txBxC.Text = "0";
            txBxA.Text = "0";
            txBxB.Text = "0";
            Старт.Enabled = true;
            rdBtnMP.Enabled = true;
            rdBtnOU.Enabled = true;

            dgvA.Enabled = true;
            dgvB.Enabled = true;

            // Сброс ячеек регистров
            foreach (DataGridView dtg in dgvArray)
            {
                for (Byte col = 0; col < dtg.Columns.Count; col++)
                {
                    dtg[col, 0].Value = "0";
                }
            }
            END();
            Старт.Enabled = true;
        }

        #region Дублирование CheckBox`ов
        private void chkBxMPa0_CheckedChanged(object sender, EventArgs e)
        {
            chkBxMPa0end.Checked = chkBxMPa0.Checked;
            //chkBxOUa0.Checked = chkBxMPa0.Checked;
        }

        private void chkBxMPa1_CheckedChanged(object sender, EventArgs e)
        {
            //chkBxOUa1.Checked = chkBxMPa1.Checked;
        }

        private void chkBxMPa2_CheckedChanged(object sender, EventArgs e)
        {
            // Corrected to reference chkBxMPa2.Checked (not chkBxMPa1)
            //chkBxOUa2.Checked = chkBxMPa2.Checked;
        }

        private void chkBxMPa3_CheckedChanged(object sender, EventArgs e)
        {
            // Corrected to reference chkBxMPa3.Checked (not chkBxMPa2)
            //chkBxOUa3.Checked = chkBxMPa3.Checked;
        }
        #endregion

        /* Сброс ячеек DataGridView в 0 при создании */
        private void dtGridBindingContextChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            for (Byte col = 0; col < dgv.Columns.Count; col++)
            {
                dgv[col, 0].Value = "0";
            }
        }

        private void rdBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            Старт.Text = "Пуск";
        }

        private void rdBtnStep_CheckedChanged(object sender, EventArgs e)
        {
            Старт.Text = "Такт";
        }

        private void rdBtnMP_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLevels.SelectedIndex = 0;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void grBxRegisters_Enter(object sender, EventArgs e)
        {

        }

        private void picBxOperUnit_Click(object sender, EventArgs e)
        {

        }

        private void dgvRgC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rdBtnOU_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLevels.SelectedIndex = 1;
        }

        // Конец МП
        private void END()
        {
            a = 0;
            run = false;
            x = new bool[7];
            Q = new bool[2];
            D = new bool[2];
            y = new bool[10];
            A_out = new bool[4];
            isRead = false;
            count = 0;
            Старт.Enabled = false;
            showForm();
        }

    }
}
