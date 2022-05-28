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

% 14 длина списка, вывод, ввод

lengthlist([],0):-!.
lengthlist([_|T], CNTS) :- length(T,I), CNTS is I + 1.

readList(0,[]) :- !.
readList(I,[X|T]) :- write('input - '),read(X), I1 is I - 1, readList(I1, T).

write_list([]) :- !.
write_list([X|T]) :- write(X), nl, write_list(T).

%15(3)
% Дан целочисленный массив и натуральный индекс (число, меньшее
% размера массива). Необходимо определить является ли элемент по указанному индексу глобальным максимумом.

byindex(L,I,El):-byindex(L,I,El,0).
byindex([H|_],K,H,K):-!.
byindex([_|Tail],I,El,Cou):-
    I =:= Cou,
    byindex(Tail,Cou,El,Cou);
    Cou1 is Cou + 1,
    byindex(Tail,I,El,Cou1).

maxEl(L,El):- maxEl(L,-1000,El).
maxEl([],El,El):-!.
maxEl([H|T],M,El):-
    (H>M,M1 is H),
    maxEl(T,M1,El);
    maxEl(T,M,El).

ask15:-
    write('input N -> '),
    read(N),
    readList(N,L),
    write('input I -> '),
    read(I),
    byindex(L,I,Elind),
    maxEl(L,Elmax),
    (Elind =:= Elmax,write(yes);write(no)),!.

%16(11) Дан целочисленный массив, в котором лишь один элемент отличается от остальных. Необходимо найти значение этого элемента.

count(L,N,Ot):-count(L,N,Ot,0).
count([],_,K,K):-!.
count([H|T],El,Ot,K):-
    H =:= El, K1 is K+1,!,
    count(T,El,Ot,K1);
    count(T,El,Ot,K),!.


ch(L,Ot):-ch(L,L,Ot,0).
ch([],_,K,K):-!.
ch([H|T],L,Ot,C):-
    count(L,H,K),
    K =:= 1,!,
    ch(T,L,Ot,H);
    ch(T,L,Ot,C),!.
ask16:-
    write('input N -> '),
    read(N),
    readList(N,L),
    ch(L,K),
    write(K).

%17(13) Дан целочисленный массив. Необходимо разместить элементы, расположенные до минимального, в конце массива.

indMinEl([H|T],Ot):-indMinEl(T,Ot,0,1,H).
indMinEl([],K,K,_,_):-!.
indMinEl([H|T],Ot,IM,I,Min):-
    (   H<Min,IM1 is I,Min1 is H;
    IM1 is IM,Min1 is Min),
    I1 is I+1,
    indMinEl(T,Ot,IM1,I1,Min1).

concatList([], List2, List2).
concatList([H|T],List2,[H|NewList]) :- concatList(T,List2,NewList).

moveBeforeMin([H|T],List):-indMinEl([H|T],Ind),
    moveBeforeMin([H|T],List,Ind,0,[]).
moveBeforeMin(L1,List,IndMin,IndMin,L2):- concatList(L1,L2,List),!.
moveBeforeMin([H|T],List,IndMin,IndNow,NowList):-
    NewInd is IndNow+1, concatList(NowList,[H],NewList),
    moveBeforeMin(T,List,IndMin,NewInd,NewList).
ask17:-
    write('Input N -'),
    read(N),
    readList(N,List),
    moveBeforeMin(List,NewList),
    write('New List: '),
    write_list(NewList),!.

%18(15) Дан целочисленный массив и натуральный индекс (число, меньшее
% размера массива). Необходимо определить является ли элемент по указанному индексу локальным минимумом.

locMin(L,I):-I1 is I -1, I2 is I+1,byindex(L,I1,El1),
    byindex(L,I,El),
    El1>El,!.
locMin(L,I):-I1 is I -1, I2 is I+1,
    byindex(L,I,El),byindex(L,I2,El2),
    El2>El,!.
locMin(L,I):-I1 is I -1, I2 is I+1,byindex(L,I1,El1),
    byindex(L,I,El),byindex(L,I2,El2),
    El1>El,El2>El,!.

ask18:-
    write('Input N -> '),
    read(N),
    readList(N,L),
    write('Input I -> '),
    read(I),
    locMin(L,I),!.

%19(27) Дан целочисленный массив. Необходимо осуществить циклический сдвиг элементов массива влево на одну позицию.

appendList([],X,X).
appendList([X|T],Y,[X|T1]) :- appendList(T,Y,T1).


shift(Result, 0, Result) :- !.
shift([X|T], N, Result) :-
    N1 is N - 1,
    appendList(T, [X], NewList),
    shift(NewList, N1, Result), !.

ask19:-
    write('Input N -> '),
    read(N),
    readList(N,L),
    shift(L,1,K), write_list(K).

% 20(30) Дан целочисленный массив и натуральный индекс (число, меньшее
% размера массива). Необходимо определить является ли элемент по указанному индексу локальным максимумом.

locMax(L,I):-I1 is I -1, I2 is I+1,
    byindex(L,I,El),byindex(L,I2,El2),
    El2<El,!.

locMax(L,I):-I1 is I -1, I2 is I+1,byindex(L,I1,El1),
    byindex(L,I,El),
    El1<El!.

locMax(L,I):-I1 is I -1, I2 is I+1,byindex(L,I1,El1),
    byindex(L,I,El),byindex(L,I2,El2),
    El1<El,El2<El,!.

ask20:-
    write('Input N -'),
    read(N),
    readList(N,L),
    write('Input I -'),
    read(I),
    locMax(L,I),!.