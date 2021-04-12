% Дз #2 (матан) Савко Богдан Геннадьевич.

%% Task 1.1
fun = @fun1;
x0 = [0;0];
x = fsolve(fun, x0)
clear();
%% Task 1.2
fun = @fun2;
x0 = [0;0;0];
x = fsolve(fun, x0)

%% Task 2.
syms x;
lim1 = limit((10+x)^(1/x), x, 0, 'right')
lim2 = limit((10+x)^(1/x), x, 0, 'left')
clear();

%% Task 3.
syms deltax x;
diff(atan(x), x)
f = (atan(deltax + x) - atan(x))/deltax;
diff_by_lim = limit(f,deltax,0)
clear();

%% Task 4.
syms x;
limit((9*x^2-1)/(x+1/3), x, -1/3)
clear();

%% Task 5.
syms x;
diff((3*cos(5*x^2))^3, x)
clear();

%% Task 6.1.
syms x y z;
u = sin(x + 2*y) + 2*sqrt(x*y*z);
difx = diff(u, x, 2)
dify = diff(u, y, 2)
difz = diff(u, z, 2)
difxy = diff(difx, y)
difxz = diff(difx, z)
difyz = diff(dify, z)
clear();

%% Task 6.2.
syms x y z;
u = log(3-x^2)+x*y^2*z;
difx = diff(u, x, 2)
dify = diff(u, y, 2)
difz = diff(u, z, 2)
difxy = diff(difx, y)
difxz = diff(difx, z)
difyz = diff(dify, z)
clear();

%% Task 6.3.
syms x y z;
u = x^2 - atan(y+z^3);
difx = diff(u, x, 2)
dify = diff(u, y, 2)
difz = diff(u, z, 2)
difxy = diff(difx, y)
difxz = diff(difx, z)
difyz = diff(dify, z)
clear();

%% Task 6.4.
syms x y z;
u = x^3*y^2*z+3*x-5*y+z+2;
difx = diff(u, x, 2)
dify = diff(u, y, 2)
difz = diff(u, z, 2)
difxy = diff(difx, y)
difxz = diff(difx, z)
difyz = diff(dify, z)
clear();

%% Task 7.
syms x;
y1 = sin(x)/x;
y2 = (1-exp(-x))/x;
y3 = (1 - x)/log(x);

lim1 = limit(y1, x, 0)
lim2 = limit(y2, x, inf)
lim3 = limit(y3, x, 1)
clear();

%% Task 8.
syms x;
diff(x^2*cos(2*x), x, 5)
clear();
%% Task 9.
syms x;
limit(1-exp(-x)/x,x, inf)
clear();
%% Task 10.
syms a x n;
y = exp(-a*x^5)+log(a^n+x^a)-a*n/x^3;
diff(y, x)
clear();

