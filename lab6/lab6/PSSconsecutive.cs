using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    public class PSSconsecutive
    {
        // Система массового обслуживания

        public int AccumulationSpeed { get; set; } // Скорость поступления заявок
        public int ProcessingSpeed { get; set; } // Скорость обработки заявок
        public int NumberOfServers { get; set; } // Количество серверов
        public int QueueSize { get; set; } // Размер очереди

        public int CurrentQueueCount => requestQueue.Count;

        public List<double> WaitTimesPerHour { get; private set; } = new List<double>();

        private Queue<Request> requestQueue; // Очередь заявок
        private List<Request> processedRequestsList; // Список обработанных заявок
        private int droppedRequests; // Количество отброшенных заявок

        // Конструктор для инициализации СМО
        public PSSconsecutive(int accumulationSpeed, int processingSpeed, int numberOfServers, int queueSize)
        {
            AccumulationSpeed = accumulationSpeed;
            ProcessingSpeed = processingSpeed;
            NumberOfServers = numberOfServers;
            QueueSize = queueSize;

            requestQueue = new Queue<Request>();
            processedRequestsList = new List<Request>();
            droppedRequests = 0;
        }

        // Моделирование работы СМО за заданное количество часов
        public double Simulate(int hours)
        {
            double totalWaitTime = 0;
            int totalProcessedRequests = 0;

            // Инициализируем список для средней задержки по каждому часу
            WaitTimesPerHour = new List<double>();

            for (int t = 0; t < hours; t++)
            {
                // Этап 1: Поступление заявок
                for (int i = 0; i < AccumulationSpeed; i++)
                {
                    Request newRequest = new Request(t); // Создание новой заявки
                    if (requestQueue.Count < QueueSize)
                    {
                        requestQueue.Enqueue(newRequest); // Добавление заявки в очередь
                    }
                    else
                    {
                        droppedRequests++; // Если очередь переполнена, заявка отброшена
                    }
                }

                // Этап 2: Обработка заявок
                List<Request> processedThisHour = new List<Request>();
                for (int i = 0; i < NumberOfServers; i++)
                {
                    if (requestQueue.Count > 0)
                    {
                        Request request = requestQueue.Dequeue(); // Извлекаем заявку из очереди
                        request.ProcessedTime = t + 1; // Время обработки заявки
                        processedThisHour.Add(request);
                        processedRequestsList.Add(request);
                        totalProcessedRequests++;
                        totalWaitTime += (request.ProcessedTime - request.ArrivalTime); // Рассчитываем общее время ожидания
                    }
                }

                // Этап 3: Среднее время ожидания за текущий час
                double averageWaitThisHour = processedThisHour.Count > 0
                    ? processedThisHour.Average(r => (r.ProcessedTime - r.ArrivalTime))
                    : 0;

                WaitTimesPerHour.Add(averageWaitThisHour);
            }

            // Финальный расчет фитнеса
            return CalculateFitness(totalProcessedRequests, totalWaitTime);
        }

        // Функция фитнеса, основанная на времени ожидания, количестве отброшенных заявок и переработке
        private double CalculateFitness(int totalProcessedRequests, double totalWaitTime)
        {
            // 1. Извлекаем значения для фитнеса (аналог extractValues из ParallelSpecimen)
            double accSpeed = AccumulationSpeed;
            double procSpeed = ProcessingSpeed;
            double numberOfServers = NumberOfServers;
            double queueSize = QueueSize;

            // 2. Проверка на некорректные значения (аналог безопасных проверок из оригинального getFitness)
            if (procSpeed == 0 || numberOfServers == 0)
                return 0;

            double wS = 1.0 / procSpeed;
            double p = accSpeed / (numberOfServers * procSpeed);

            if (p >= 1.0)
                return 0;

            // 3. Расчет параметров для фитнеса, как в оригинальной функции
            double averageWaitTime = (Math.Pow(accSpeed, 2) * Math.Pow(wS, 2)) / (2 * (1 - p));
            double averageRequestCount = accSpeed * (wS + averageWaitTime);
            double overloadPercent = Math.Pow(p, numberOfServers);

            // 4. Теперь вычисляем фитнес:
            double fitness = (1.0 / (1.0 + averageWaitTime)) +
                             (1.0 / (1.0 + averageRequestCount)) +
                             (1.0 - overloadPercent);

            // 5. Увеличиваем вес размера очереди в расчете фитнеса
            double queueSizeFactor = 0.1; // Коэффициент веса для размера очереди (можно настроить)
            fitness += queueSize * queueSizeFactor;

            // 6. Если система отбросила заявки, пенализируем ее (добавляем штраф за отброшенные заявки)
            double dropPenalty = droppedRequests * 0.1; // Можно регулировать коэффициент
            fitness -= dropPenalty;

            return fitness;
        }

        // Получить статистику по заявкам
        public string GetStats()
        {
            double totalWaitTime = 0;
            foreach (var request in processedRequestsList)
            {
                totalWaitTime += (request.ProcessedTime - request.ArrivalTime);
            }

            double averageWaitTime = processedRequestsList.Count > 0 ? totalWaitTime / processedRequestsList.Count : 0;
            return $"Обработано заявок: {processedRequestsList.Count},\nОтброшено заявок: {droppedRequests},\nСреднее время ожидания: {averageWaitTime}";
        }
    }

    // Класс, представляющий заявку
    public class Request
    {
        public int ArrivalTime { get; set; } // Время поступления заявки
        public int ProcessedTime { get; set; } // Время обработки заявки

        public Request(int arrivalTime)
        {
            ArrivalTime = arrivalTime;
            ProcessedTime = -1; // Пока не обработана
        }
    }
}
