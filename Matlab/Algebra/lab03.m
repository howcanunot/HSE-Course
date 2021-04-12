%% 
% Савко Богдан Геннадьевич (Алгебра 4)
%% Task 1

a = [2 3 4];
b = [3 5 2];
c = [1 1 1];

aplusb = a + b;
bplusa = b + a;
is_equal = (aplusb == bplusa)
is_equal_using_isequal = isequal(aplusb,bplusa)

figure
grid on
quiver3(0, 0,0, 2, 3,4, 1)
hold on
axis equal
quiver3(0, 0,0, 3, 5,2)
quiver3(0, 0,0, aplusb(1), aplusb(2), aplusb(3))



aplusbandthenplusc = (a + b) + c;
aplusbplusc = a + (b + c);
is_equal = (aplusbandthenplusc == aplusbplusc)
is_equal_using_isequal = isequal(aplusbplusc, aplusbandthenplusc)

figure
grid on
quiver3(0, 0,0, 2, 3,4, 1)
hold on
axis equal
quiver3(0, 0,0, 3, 5,2)
quiver3(0,0,0,c(1),c(2),c(3))
quiver3(0, 0,0, aplusbplusc(1), aplusbplusc(2), aplusbplusc(3))
%% Task 2

a = ([4, 2, 3])';
b = ([1, 5, 2])';
alp = 4;
bet = 3;
% Дистрибутивность 1
isequal( alp * (a+b) , alp * a + alp * b)
% Дистрибутивность 2
isequal( a * (alp + bet) , a * alp + a * bet)
% Ассоциативность
isequal( alp * (bet * a) , (alp * bet) * a)
%% Task 3.1

length = sqrt(a(1) * a(1) +a(2) * a(2) + a(3) * a(3))
length_norm = norm(a)
ort_a = a ./ length
is_equal = isequal(norm(ort_a),1)
%% Task 3.2

b = [4 2]
length = sqrt(b(1) * b(1) +b(2) * b(2))
length_norm = norm(b)
ort_b = b ./ length
is_equal = isequal(norm(ort_b),1)
%% Task 4

a = ([3, 4, 5])';
cosa = a(1,1) / norm(a); cosb = a(2,1) / norm(a); coso = a(3,1) / norm(a);
fprintf('угол наклона к Ox: %f\n', acos(cosa) / pi * 180)
fprintf('угол наклона к Oy: %f\n', acos(cosb) / pi * 180)
fprintf('угол наклона к Oz: %f\n', acos(coso) / pi * 180)

fprintf('сумма квадратов направляющих косинусов: %f\n', cosa * cosa + cosb * cosb + coso * coso)

b = ([4, 2])';
cosa = b(1,1) / norm(b); cosb = b(2, 1) / norm(b);
fprintf('угол наклона к Ox: %f\n', acos(cosa) / pi * 180)
fprintf('угол наклона к Oy: %f\n', acos(cosb) / pi * 180)
fprintf('сумма квадратов направляющих косинусов: %f\n', cosa * cosa + cosb * cosb)

%% Task 5

a = [1 -2 0];
b = [0 1 1];
c = [1 2 2];
d = [a;
    b;
    c];
determinant = det(d)
figure
grid on
quiver3(0, 0,0, 1, 0,0, 1,'black','lineWidth',4)
hold on
axis equal
quiver3(0, 0,0, 0, 1,0, 1,'black','lineWidth',4)
quiver3(0, 0, 0, 0, 0, 1,1,'black','lineWidth',4)
quiver3(0, 0,0, 1, -2,0, 1)
quiver3(0, 0,0, 0, 1,1, 1)
quiver3(0, 0,0, 1, 2,2, 1)
ort_a = a ./ norm(a);
ort_b = b ./ norm(b);
ort_c = c ./ norm(c);
quiver3(0, 0,0, ort_a(1), ort_a(2), ort_a(3), 1,'black','lineWidth',4)
quiver3(0, 0,0, ort_b(1), ort_b(2), ort_b(3), 1,'black','lineWidth',4)
quiver3(0, 0,0, ort_c(1), ort_c(2), ort_c(3), 1,'black','lineWidth',4)
%% Task 6

p = [2, -3];
q = [1, 2];
% Проверка на коллинеарность
dot(p, q)

s = [9, 4]';
x = [p ; q]' \ s;
m = x(1, 1); n = x(2, 1);

figure;
grid on;
hold on;
axis equal;

quiver(0, 0, p(1, 1), p(1, 2), 1)
quiver(0, 0, q(1, 1), q(1, 2), 1)
text(1.15, 2, '\bfq')
text(2, -2.6, '\bfp')

quiver(0, 0, m * p(1, 1), m * p(1, 2), 1)
quiver(0, 0, n * q(1, 1), n * q(1, 2), 1)
text(n * 1.15, n * 2, '\bfnq')
text(m * 2, m * -2.6, '\bfmp')

quiver(0, 0, s(1, 1), s(2, 1), 1)
text(9.5, 4, '\bfs')

quiver(0,0,10,0,1,'LineWidth',2)
quiver(0,0,0,10,1,'LineWidth',2)
quiver(0,0,1,0,1,'black', 'LineWidth',4)
quiver(0,0,0,1,1,'black', 'LineWidth',4)
%% Task 7

figure

subplot (2,2,1)
grid on
axis equal
hold on
quiver(0, 0, 10, 0, 1,'lineWidth',2)
quiver(0, 0, 0, 10, 1,'lineWidth',2)
quiver(0, 0, 0, 1, 1,'black','lineWidth',4)
quiver(0, 0, 1, 0, 1,'black','lineWidth',4)
quiver(0,0,3,2,1)
quiver(0,0,-2,1,1)
quiver(0,0,4,-4,1)

subplot(2,2,2)
grid on
axis equal
hold on
quiver(0, 0, 10, 0, 1,'lineWidth',2)
quiver(0, 0, 0, 10, 1,'lineWidth',2)
quiver(0, 0, 0, 1, 1,'black','lineWidth',4)
quiver(0, 0, 1, 0, 1,'black','lineWidth',4)
quiver(0,0,-5,-7/4,1, 'red')
quiver(0,0,-2,1,1, 'blue')
quiver(0,0,4,-4,1, 'blue')

subplot(2,2,3)
grid on
axis equal
hold on
quiver(0, 0, 10, 0, 1,'lineWidth',2)
quiver(0, 0, 0, 10, 1,'lineWidth',2)
quiver(0, 0, 0, 1, 1,'black','lineWidth',4)
quiver(0, 0, 1, 0, 1,'black','lineWidth',4)
quiver(0,0,3,2,1, 'blue')
quiver(0,0,-1/5,-7/20,1, 'red')
quiver(0,0,4,-4,1, 'blue')

subplot (2,2,4)
grid on
axis equal
hold on
quiver(0, 0, 10, 0, 1,'lineWidth',2)
quiver(0, 0, 0, 10, 1,'lineWidth',2)
quiver(0, 0, 0, 1, 1,'black','lineWidth',4)
quiver(0, 0, 1, 0, 1,'black','lineWidth',4)
quiver(0,0,3,2,1, 'blue')
quiver(0,0,-2,1,1, 'blue')
quiver(0,0,-4/7,-20/7,1 ,'red')
%% Task 8

a = [2, 1, 0];
b = [1, -1, 2];
c = [2, 2, -1];
d = [3, 7, -7];

x = [b; c; d]' \ a'
n = x(1, 1); m = x(2, 1), k = x(3, 1);

figure
subplot(1, 2, 1)
grid on
axis equal
axis tight
quiver3(0,0,0,10,0,0,1,'LineWidth',2)
hold on
quiver3(0,0,0,0,10,0,1,'LineWidth',2)
quiver3(0,0,0,0,0,10,1,'LineWidth',2)
quiver3(0,0,0,1,0,0,1,'black', 'LineWidth',2)
quiver3(0,0,0,0,1,0,1,'black', 'LineWidth',2)
quiver3(0,0,0,0,0,1,1,'black', 'LineWidth',2)

quiver3(0,0,0,a(1),a(2),a(3), 1,'LineWidth',2)

quiver3(0,0,0,b(1),b(2),b(3), 1,'LineWidth',1)
quiver3(0,0,0,c(1),c(2),c(3), 1,'LineWidth',1)
quiver3(0,0,0,d(1),d(2),d(3), 1,'LineWidth',1)
hold off

text(a(1), a(2), a(3), '\bfa')
text(b(1), b(2), b(3), '\bfb')
text(c(1), c(2), c(3), '\bfc')
text(d(1), d(2) + 0.4, d(3), '\bfd')
view([119.18 6.53])

subplot(1, 2, 2)
grid on
axis equal
quiver3(0,0,0,8,0,0,1,'LineWidth',2)
hold on
quiver3(0,0,0,0,8,0,1,'LineWidth',2)
quiver3(0,0,0,0,0,8,1,'LineWidth',2)
quiver3(0,0,0,b(1),b(2),b(3), 1,'blue', 'LineWidth',1)
quiver3(0,0,0,c(1),c(2),c(3), 1,'blue', 'LineWidth',1)
quiver3(0,0,0,d(1),d(2),d(3), 1,'blue', 'LineWidth',1)
quiver3(0,0,0,a(1),a(2),a(3), 1,'red', 'LineWidth',3)

view([119.18 6.53])

subplot(1,2,1)
view([167.4 13.4])
subplot(1,2,2)
view([158.3 7.5])

subplot(1,2,2)
view([254.18 3.58])
%% Task 9

a = [1 -2 0];
b = [0 1 2];
c = [1 2 2];

%% Task 9.1

ab = dot(a,b);
ba = dot(b,a);
is_equal = isequal(ab,ba)

%% Task 9.2


abc = dot(a+b, c);
acbc = dot(a,c) + dot(b,c);
is_equal = isequal(abc,acbc)

%% Task 9.2`

abc = dot(a, b + c);
abac = dot(a,b) + dot(a,c);
is_equal = isequal(abc,abac)

%% Task 9.3

alpha = -5;
alphaab = dot(alpha * a, b);
alpha_ab = alpha * dot(a,b);
is_equal = isequal(alphaab,alpha_ab)

%% Задание 9.3'

alpha = -5;
alphaab = dot(a, alpha * b);
alpha_ab = alpha * dot(a,b);
is_equal = isequal(alphaab,alpha_ab)

%% Task 9.4

square = dot(a,a)
a = [0 0 0];
square_but_a_is_zero = dot(a,a)
%% Task 10

a = [1,-2,0];
b = [0,1,2];
c = [1,2,2];
% Опровежение равенства 1
isequal( dot(a, b) * c , a * dot(b, c) )
% Опровержение равенства 2
fprintf('dot(a, b): %f', dot(a, b))
fprintf('dot(a, c): %f', dot(a, c))
% Опровежение равенства 3
isequal(dot(a, b) * b, a * dot(b, b))