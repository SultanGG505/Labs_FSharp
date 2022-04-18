man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).

parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

man:-man(X),print(X),nl,fail.
woman:- woman(X),print(X),nl,fail.
parent:- parent(X,zdislava),print(X),nl,fail.
mother(X,Y):-woman(X),parent(X,Y).
brother(X,Y):- parent(Z,X),parent(Z,Y),X\=Y.
grand_pa(X,Y):-parent(X,Z),parent(Z,Y).
uncle(X,Y):-brother(X,Z),parent(Z,Y).
max(X,Y,Z):-(X>=Y -> Z is X);(Y>=X -> Z is Y).
fact_up(0,1).
fact_up(N,X):-N1 is N-1,fact_up(N1,X1),X is X1*N.
fact_down(0,X,X).
fact_down(N,A,X):-A1 is A*N,N1 is N-1,fact_down(N1,A1,X).
fact_down(N,X):-fact_down(N,1,X).
sum_dig(0,0).
sum_dig(N,X):-N1 is N div 10,sum_dig(N1,X1),X is X1+(N mod 10).
