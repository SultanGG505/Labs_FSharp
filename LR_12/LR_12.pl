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