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

/* Task 11*/
/*������� � 3. ��������� �������� daughter(X, Y), ������� ���������,
�������� �� X ������� Y. ��������� ��������, daughter(X), �������
������� ���� X.*/

daughter(X):- parent(X,Y),woman(Y),write(Y),nl,fail.
daughter(X,Y):- woman(X),parent(Y,X).







