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

