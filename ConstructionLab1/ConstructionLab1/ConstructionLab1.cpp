#include <iostream>
#include <vector>
#include <limits>
#include <iomanip>
#include <cmath>

using namespace std;

double f(double x) {
    return x * x * x - 4 * x * x + x + 6;
}

double read_double(const string& prompt) {
    double value;
    while (true) {
        cout << prompt;
        if (cin >> value) return value;
        cout << "Error! Enter a number: ";
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
}

int read_int(const string& prompt, int min, int max) {
    int value;
    while (true) {
        cout << prompt;
        if (cin >> value && value >= min && value <= max) return value;
        cout << "Error! Enter " << min << ".." << max << ": ";
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
}

void program1() {
    int n = read_int("Points count (2..100): ", 2, 100);
    vector<double> x(n), y(n);

    for (int i = 0; i < n; i++) {
        x[i] = read_double("x[" + to_string(i + 1) + "] = ");
        y[i] = read_double("y[" + to_string(i + 1) + "] = ");
    }

    double sumx = 0, sumy = 0, minx = x[0], maxx = x[0], miny = y[0], maxy = y[0];

    for (int i = 0; i < n; i++) {
        sumx += x[i]; sumy += y[i];
        if (x[i] < minx) minx = x[i]; if (x[i] > maxx) maxx = x[i];
        if (y[i] < miny) miny = y[i]; if (y[i] > maxy) maxy = y[i];
    }

    cout << "\nStatistics:\nX: Sum=" << sumx << " Avg=" << sumx / n << " Min=" << minx << " Max=" << maxx;
    cout << "\nY: Sum=" << sumy << " Avg=" << sumy / n << " Min=" << miny << " Max=" << maxy << "\n";
}

void program2() {
    double x0 = read_double("Start X: ");
    double x1 = read_double("End X: ");
    double h = read_double("Step: ");

    if (h <= 0 & x1 < x0) {
        cout << "Invalid parameters!\n"; return;
    }

    cout << fixed << setprecision(4) << "\n  X\t  f(X)\n";
    double sumx = 0, sumy = 0, minx = x0, maxx = x0, miny = f(x0), maxy = f(x0);
    int count = 0;

    for (double x = x0; x <= x1 + h / 2; x += h) {
        double y = f(x);
        cout << x << "\t" << y << "\n";
        sumx += x; sumy += y;
        if (x < minx) minx = x; if (x > maxx) maxx = x;
        if (y < miny) miny = y; if (y > maxy) maxy = y;
        count++;
    }

    cout << "\nTable stats: Count=" << count;
    cout << "\nX: Sum=" << sumx << " Avg=" << sumx / count << " Min=" << minx << " Max=" << maxx;
    cout << "\nY: Sum=" << sumy << " Avg=" << sumy / count << " Min=" << miny << " Max=" << maxy << "\n";
}

void program3() {
    double a = read_double("Left bound: ");
    double b = read_double("Right bound: ");
    double eps = read_double("Tolerance: ");

    if (a >= b || eps <= 0) {
        cout << "Invalid parameters!\n"; return;
    }

    double fa = f(a), fb = f(b);
    cout << "Initial values:\n";
    cout << "f(" << a << ") = " << fa << "\n";
    cout << "f(" << b << ") = " << fb << "\n";

    if (fa * fb > 0) {
        cout << "No root guaranteed in interval!\n"; return;
    }

    cout << "\nIteration process:\n";
    cout << "==================================================\n";
    cout << "Iter\tLeft\t\tRight\t\tMiddle\t\tf(Middle)\n";
    cout << "--------------------------------------------------\n";

    int iter = 0;
    double c, fc;

    // Всегда выполняем хотя бы одну итерацию
    do {
        c = (a + b) / 2;
        fc = f(c);

        cout << setw(3) << iter << "\t" << setw(10) << a << "\t" << setw(10) << b;
        cout << "\t" << setw(10) << c << "\t" << setw(12) << fc << "\n";

        if (fc == 0.0) break;

        if (fa * fc < 0.0) {
            b = c;
            fb = fc;  // Обновляем fb
        }
        else {
            a = c;
            fa = fc;  // Обновляем fa
        }
        iter++;

    } while ((b - a) / 2.0 > eps && iter < 1000);

    // Финальное приближение
    c = (a + b) / 2;
    fc = f(c);

    cout << "==================================================\n";
    cout << fixed << setprecision(10);
    cout << "\nResults:\n";
    cout << "Root approximation: " << c << "\n";
    cout << "f(root) = " << fc << "\n";
    cout << "Iterations: " << iter << "\n";
    cout << "Final interval: [" << a << ", " << b << "]\n";
    cout << "Interval length: " << (b - a) << "\n";

    if (iter >= 1000) {
        cout << "Warning: Maximum iterations reached.\n";
    }
}

int main() {
    while (true) {
        cout << "\n1-Points 2-Polynomial 3-Bisection 0-Exit\nChoice: ";
        int choice; cin >> choice;

        if (choice == 0) break;
        if (choice == 1) program1();
        else if (choice == 2) program2();
        else if (choice == 3) program3();
        else cout << "Invalid choice!\n";

        cin.ignore();
        cout << "Press Enter..."; cin.get();
    }
    return 0;
}