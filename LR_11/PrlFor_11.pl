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
/*Variant № 3. Postroit predikat daughter_X_ Y,_ kotorii proveryaet_ yavlyaetsya li  X docheryu Y.
 Postroit predikat_ daughter_X,_ kotorii vivodit doch X. */

daughter(X,Y):- woman(X),parent(Y,X).
daughter(X):- parent(X,Y),woman(Y),write(Y),nl,fail.

/*Task 12*/
/*Variant № 3. Postroit predikat wife_X_ Y,_ kotorii proveryaet_ yavlyaetsya li X jenoi Y.
 Postroit predikat wife_X,_ kotorii vivodit jenu X.*/

wife(X,Y):- parent(X,Z),parent(Y,Z), ((woman(X);woman(Y)),(man(X);man(Y))).
wife(X):- man(X),parent(X,Z),parent(Y,Z),woman(Y),write(Y).

/*Task 13*/
/*Variant 3. Postroit predikat grand_ma_X_ Y,_ kotorii proveryaet_ yavlyaetsya li X babushkoi Y.
 Postroit predikat grand_mas_X,_ kotorii vivodit vseh babushek X.
*/

man(valera1).
man(valera2).
man(valera3).

woman(anna1).
woman(anna2).
woman(anna3).

parent(anna1,anna2).
parent(anna2,anna3).
/*anna1- ������� anna3(видимо кракозябра про то, кто кому бабушка)*/

grand_ma(X,Y):- woman(X),parent(X,Z),parent(Z,Y).











