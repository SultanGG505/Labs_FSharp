man(Artem).
man(Egor).
man(Daniil).
man(Sultan).
man(Valentin).
man(Alexey).
man(Artur).
man(Kirill).
man(Ivan).
man(Anton).
man(Andrei).
man(Arseniy).
man(Valera).

woman(Olga).
woman(Kristina).
woman(Katya).
woman(Valentina).
woman(Svetlana).
woman(Rita).
woman(Eleonora).
woman(Polina).
woman(Tatyana).
woman(Anna).
woman(Nastya).
woman(Natasha).
woman(Veronika).

parent(Artem,Egor).
parent(Artem,Daniil).
parent(Artem,Sultan).
parent(Artem,Valentin).

parent(Kristina,Egor).
parent(Kristina,Daniil).
parent(Kristina,Sultan).
parent(Kristina,Valentin).

parent(Alexey,Kirill).
parent(Alexey,Tatyana).
parent(Eleonora,Kirill).
parent(Eleonora,Tatyana).

parent(Ivan,Anton).
parent(Ivan,Polina).
parent(Anna,Anton).
parent(Anna,Polina).

parent(Andrei,Rita).
parent(Andrei,Svetlana).
parent(Katya,Rita).
parent(Katya,Svetlana).

parent(Arseniy,Nastya).
parent(Arseniy,Valera).
parent(Natasha,Nastya).
parent(Natasha,Valera).

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
/*text/


/*11 num/
