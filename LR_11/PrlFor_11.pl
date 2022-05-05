man(artem).
man(egor).
man(daniil).
man(sultan).
man(valentin).
man(alexey).
man(artur).
man(kirill).
man(ivan).
man(anton).
man(andrei).
man(arseniy).
man(valera).

woman(olga).
woman(kristina).
woman(katya).
woman(valentina).
woman(svetlana).
woman(rita).
woman(eleonora).
woman(polina).
woman(tatyana).
woman(anna).
woman(nastya).
woman(natasha).
woman(veronika).

parent(artem,egor).
parent(artem,daniil).
parent(artem,sultan).
parent(artem,valentin).

parent(kristina,egor).
parent(kristina,daniil).
parent(kristina,sultan).
parent(kristina,valentin).

parent(alexey,kirill).
parent(alexey,tatyana).
parent(eleonora,kirill).
parent(eleonora,tatyana).

parent(ivan,anton).
parent(ivan,polina).
parent(anna,anton).
parent(anna,polina).

parent(andrei,rita).
parent(andrei,svetlana).
parent(katya,rita).
parent(katya,svetlana).

parent(arseniy,nastya).
parent(arseniy,valera).
parent(natasha,nastya).
parent(natasha,valera).

man:-man(X),print(X),nl,fail.
woman:- woman(X),print(X),nl,fail.

% Task 11 Вариант № 3. Построить предикат daughter(X, Y), который проверяет, является ли  X дочерью Y.
% Построить предикат, daughter(X), который выводит дочь X. 

daughter(X,Y):- woman(X),parent(Y,X).
daughter(X):- parent(X,Y),woman(Y),write(Y),nl,fail.

% Task 12 Вариант № 3. Построить предикат wife(X, Y), который проверяет, является ли X женой Y.
% Построить предикат wife(X), который выводит жену X.

wife(X,Y):- parent(X,Z),parent(Y,Z), ((woman(X);woman(Y)),(man(X);man(Y))).
wife(X):- man(X),parent(X,Z),parent(Y,Z),woman(Y),write(Y).

% Task 13 Вариант 3. Построить предикат grand_ma(X, Y), который проверяет, является ли X бабушкой Y. 
% Построить предикат grand_mas(X), который выводит всех бабушек X.

man(valera1).
man(valera2).
man(valera3).

woman(anna1).
woman(anna2).
woman(anna3).

parent(anna1,anna2).
parent(anna2,anna3).
% anna1- ������� anna3(видимо кракозябра про то, кто кому бабушка)

grand_ma(X,Y):- woman(X),parent(X,Z),parent(Z,Y).
grand_mas(X) :- parent(Y,X),parent(Z,Y),print(Z),nl,fail.

% Task 14 Вариант 3. Построить предикат grand_ma_and_da(X,Y), 
% который проверяет, являются ли X и Y бабушкой и внучкой или внучкой и бабушкой.

grand_ma_and_da(X,Y) :- woman(Y),woman(X),(grand_ma(X,Y);grand_ma(Y,X)).

% Task 15 Найти минимальную цифру числа с помощью рекурсии вверх.

mindigit_up(0,9) :- !.
mindigit_up(X,Digit) :- X1 is X div 10, mindigit_up(X1,Dig1), Dig2 is X mod 10, (Dig1 < Dig2, Digit is Dig1; Digit is Dig2), !.