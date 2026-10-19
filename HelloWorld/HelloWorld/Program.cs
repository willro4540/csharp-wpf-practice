int[] x = { 100 };
int[] y = x;
x[0] = 200;

Console.WriteLine(x[0]);
Console.WriteLine(y[0]);