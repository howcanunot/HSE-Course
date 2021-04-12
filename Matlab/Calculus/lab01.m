%% 
% Савко Богдан Геннадьевич Матан 3
%% Задание 1


figure
grid on
hold on
x = -2:0.01:2;
y = exp(-x) .* sin(10*x);
plot(x,y)

%% Задание 2


figure
grid on
hold on
x = 0:0.001:5;
y = exp(-x) .* sin(10*x);
area(x,y,'DisplayName','y')
comet(x,y)
z = x;
hold off
comet3(x,y,z)
view([-58 -13])

%% Задание 3

figure
axis equal
grid on

x = [2.5 1 2 3 1.5];
pie3(x,[0 1 0 0 0])

%% Задание 4

figure
grid on
hold on
x = 0:0.01:1;
y = exp(-x) .* (sin(x) + 0.1 .* sin(100*pi.*x));
plot(x,y, 'r')
x = 0:1/99:1;
y = exp(-x) .* (sin(x) + 0.1 .* sin(100*pi.*x));
plot(x,y, 'b')
%% Задание 5

figure
grid on
x = 0:0.01:10;
y = log(2*x);
loglog(x,y)
hold on
x = 0:0.01:10;
y = log(2*x).*sin(2*x);
loglog(x,y,'r')
legend("f(x)","g(x)",'Location','northwest')
xlabel('x')
ylabel('y')


figure
grid on
x = 0:0.01:10;
y = log(2*x);
semilogx(x,y)
hold on
x = 0:0.01:10;
y = log(2*x).*sin(2*x);
semilogx(x,y,'r')
legend("f(x)","g(x)",'Location','northwest')
xlabel('x')
ylabel('y')

figure
grid on
x = 0:0.01:10;
y = log(2*x);
semilogy(x,y)
hold on
x = 0:0.01:10;
y = log(2*x).*sin(2*x);
semilogy(x,y,'r')
legend("f(x)","g(x)",'Location','northwest')
xlabel('x')
ylabel('y')

%% Задание 6

figure
grid on
hold on
t = -pi:0.01:pi;
x = 2 * sin(t);
y = 4 * cos(t);
plot(x,y)
hold off
%% Задание 7

[x,y]=meshgrid(-2:0.05:2);
z = 4 .* sin(2*pi*x) .* cos(1.5*pi*y) .* (1 - y.*y) .* x .*(1 - x);
mesh(x,y,z)
view([-47.7 4.5])

%% Задание 8

[x,y]=meshgrid(-2:0.05:2);
z = 4 .* sin(2*pi*x) .* cos(1.5*pi*y) .* (1 - y.*y) .* x .*(1 - x);
levels = -3:0.01:3;
contour3(x,y,z,levels)
colorbar;
view([-38.1 13.0])
%% Задание 9

[x,y]=meshgrid(-2:0.05:2);
z = 4 .* sin(2*pi*x) .* cos(1.5*pi*y) .* (1 - y.*y) .* x .*(1 - x);
[Az, E1] = view;
colormap('copper')
shading interp
surfl(x, y, z, [Az - 90, 45])
colorbar;
%% Задание 10

figure
[x,y] = meshgrid(-1:0.05:1);

z = ((sin(x)).^2+(cos(y))^2).^(x .* y);
figure
subplot(2, 2, 1)
mesh(z)
view(-10, 20)
subplot(2, 2, 2)
surf(z)
view(-30, 90)

subplot(2, 2, 3)
contour3(z, (-10:0.05:10))
view(-30, 50)

subplot(2, 2, 4)
surfl(z,[-40 20])
view(20, 60)