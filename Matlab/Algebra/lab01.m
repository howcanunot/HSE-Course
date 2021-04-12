% Савко Богдан Геннадьевич БПИ203
%% Task 1 - 2.
A = [3.25 -1.07 2.34;
    10.10 0.25 -4.78;
    5.04 -7.79 3.31];
B = randi([0, 1], 3, 3);
display(A)
display(B)
%% Task 3.
var1 = A + 10.*B
var2 = A.*B
var3 = B'
%% Task 4.
detB = det(B);
display(detB)
%% Task 5.
C = zeros(3, 1);
C(2,1) = 5.71;
C(3,1) = -3.61;
display(C)
%% Task 6.
x = A\C;
display(x)
%% Task 7.
syms x
f = 2*cos(x)*2*sin(x) - 1 * 1;
x = solve(f);
display(x)
%% Task 8.
% a)
A = [2, -1, -1;
    -1, 2, 1;
    3, -5, -2];
b = [3;0;1];
res = [0;0;0];
if det(A) ~= 0
    tmp = A;
    for i = 1:3
        tmp(:,i) = b;
        res(i) = det(tmp) / det(A);
        tmp(:,i) = A(:,i);
    end
end
display(res)
% b) Matrix must be square.
%% Task 9.
A = [1, 1, 1;
    1, 3,  1;
    1, 1, 3];
b = [2; 4; 0];
C = [A b];

D = rref(C);
x = D(:,4);
display(x)

%% Task 10.
A = [0, -2; 1, -3];
B = [5, 1; -1, 0];
display((3 * B)^2 - 2 * (B*(A^(-1)) - eye(2))')

%% Task 11.
A = [3.81, 0.28, 1.28, 0.75;
    2.25, 1.32, 4.58, 0.49;
    5.31, 6.38, 0.98, 1.04;
    9.39, 2.45, 3.35, 2.28];
b = [1;1;1;1];
[L, U] = lu(A);
x = U\(L\b);
res = A*x;
for i = 1:4
    fprintf('%f = %f\n', b(i), res(i))
end

%% Task 12.
Matrix = randi([0, 1], 10, 8);
disp(Matrix(end, end-1))

%% Task 13.
A = [1, -1, 3;
    2, 1, -4;
    3, 1, -3];
b = [7; -3; 1];
res = A\b;
disp(res)