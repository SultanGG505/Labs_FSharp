%11 Максимальный простой делитель числа

max(X,Y,X):-X>Y,!.
max(_,Y,Y).

pr(1):- fail.
pr(X):-pr(X,2).
pr(X,X):-!.
pr(X,I):- 0 is X mod I,!,fail.
pr(X,I):- I1 is I+1, pr(X,I1).

m_s_u(X,Y):-m_s_u(X,X,Y),!.
m_s_u(X,N,N):-
    0 is X mod N,
    pr(N),!.
m_s_u(X,N,Y):-
    N1 is N-1,
    m_s_u(X,N1,Y).

m_s_d(N,X):-m(N,N,X,2).
m(_,2,X,X):-!.
m(N,Cur,X,M):-
    pr(Cur),
    0 is N mod Cur,!,
    max(M,Cur,L),
    N1 is Cur-1,
    m(N,N1,X,L).
m(N,Cur,X,M):-
    NewCur is Cur - 1,
    m(N,NewCur,X,M).

%12 НОД максимального непростого делителя и произведения

nod(X,0,X):-!.
nod(X,Y,Z):- C is X mod Y,
    nod(Y,C,Z).

mult(X,Y):-mult(X,Y,1).
mult(0,Y,Y):-!.
mult(X,Y,Z):-
    N is X div 10,
    K is X mod 10,
    P is (Z*K),
    mult(N,Y,P).

maxdel(X,Y):-maxdel(X,X,Y),!.
maxdel(X,Y,Y):-
    0 is X mod Y,
    not(pr(Y)),!.
maxdel(X,Y,Z):-
    Y1 is Y-1,
    maxdel(X,Y1,Z).

task_12(X,Y):-
    mult(X,K),
    maxdel(X,Z),
    nod(K,Z,Y).

%13 Найдите число d, меньшее 1000, для которого десятичная дробь 1/d содержит
% самый длинный период
% Задача должна быть решена без использования списков.

divBy2(X,R) :-
    Mod is X mod 2,
    Val is X div 2,
    (0 is Mod,divBy2(Val,R);R is X).
divBy5(X,R) :-
    Mod is X mod 5,
    Val is X div 5,
    (0 is Mod,divBy5(Val,R);R is X).
numForPer(X,R) :- divBy2(X,R1),divBy5(R1,R2),R is R2.

per(D,R) :- numForPer(D,Res),per(Res,R,1),!.
per(D,R,LR) :-
    B10 is 10**LR,
    1 is B10 mod D,
    R is LR,!.
per(D,R,LR) :-
    B10 is 10**LR,
    0 is B10 mod D,
    R is 0,!.
per(D,R,LR) :-
    NewLR is LR + 1,
    per(D,R, NewLR).

findMaxPer(D) :- findMaxPer(D,2,0,2).
findMaxPer(D,1000,_,LocalIndex) :- D is LocalIndex,!.
findMaxPer(D,Index,LocalD, LocalIndex) :-
    per(Index,NextD),
    NewLocalD is max(NextD,LocalD),
    (NewLocalD>LocalD,NewLocalIndex is Index; NewLocalIndex is LocalIndex),
    NewIndex is Index + 1,
    findMaxPer(D,NewIndex, NewLocalD, NewLocalIndex),!.

% 14 длина списка

lengthlist([],0):-!.
lengthlist([_|T], CNTS) :- length(T,I), CNTS is I + 1.