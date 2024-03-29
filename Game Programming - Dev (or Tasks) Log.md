# 240224
Premiere journée de reprise pour le rendu de Game Programming.
Apres quelques soucis de motivation qui ont dure plus d'un mois, j'ai réussi a me remettre d'aplomb.
En quelque sorte, j'ai repris de "zero" - les seuls elements que j'avais presents dans mon jeu jusque la étant seulement les suivants :
- Un level design minimal et pas optimal (plateformes, fond)
- Un personnage (Mario), qui pouvait aller a droite, a gauche, et sauter

J'ai recommence car j'ai decide de changer l'univers, mais cela en gardant des mecaniques propres au jeu Mario Bros.

L'univers va s'inspirer d'elements gothiques, parfois Castlevania-esque (des sprites seront d'ailleurs tirées de jeux de la franchise), visant a donner un sentiment de mystère et d'etrange.
Le declic s'est passe de cette maniere : "Et si a la place de lancer des boules de feu... Mario lancait des bulbes d'ail pour tuer des vampires". Puis tout s'est mis en place. Plus de Mario pour donner une continuité a l'univers cela dit.

Le focus de la journée va se passer sur une level design remis a neuf.

Taches effectuées ce jour :
- [x] Creation de l'univers ✅ 2024-02-24
- [x] Rassemblement des ressources (sprites joueur et ennemis, fonds, elements de decor) ✅ 2024-02-24
- [x] Decoupage des sprites ✅ 2024-02-24
- [x] Mise en place de la premiere scene ✅ 2024-02-24
- [x] Tests animations sur certaines sprites ✅ 2024-02-24
- [x] Tests deplacement avec le script precedent ✅ 2024-02-24

# 240227
Cette journee etait consacree a la gestion du Player.
Taches effectuees ce jour :
- [x] Nouvelle mecanique de saut avec GetKeyUp et GetKeyDown pour la variation de hauteur selon l'appui sur la barre espace ✅ 2024-02-27
- [x] Flip du sprite Player ✅ 2024-02-27
- [x] Implementation de Cinemachine 2D pour une meilleure gestion de la camera ✅ 2024-02-27
- [x] Ajout du composite collider sur les tilemaps plateformes (règle le bug de personnage bloque occassionellement) ✅ 2024-02-27
- [x] Ajout musique de la premiere scene ✅ 2024-02-27

# 240228
Journee non planifiee de travail mais j'ai pense a quelques trucs a rajouter en complement.
Taches effectuées ce jour :
- [x] Confinement de la camera ✅ 2024-02-28
- [x] Confinement de la scene pour empecher le joueur d'aller au dela de ce qui est mis en place ✅ 2024-02-28
- [x] Edit de divers sprites pour le decor (gargouille, lave) ✅ 2024-02-28
- [x] Ajout effet parallaxe ✅ 2024-02-28
- [x] Implementation déplacement ennemi d'un point A a un point B (a revoir) ✅ 2024-02-28

# 240229
Journee qui etait supposee aller dans la gestion des ennemis mais contre-temps.
Taches effectuées ce jour :
- [x] Collection d'items ✅ 2024-02-29
- [x] Compteur d'items ✅ 2024-02-29
- [x] Implementation effets sonores ✅ 2024-02-29

# 240301
- [x] Redesign du player pour ses differents etats (casque equivalent de Mario Grand, tunique violette (+casque) equivalent de Mario Feu) ✅ 2024-03-01
- [x] Design boite en fer, qui donne  une fiole equivalent champignon ou fleur d'ail (equivalent fleur de feu) ✅ 2024-03-01
- [x] Destruction de l'ennemi en sautant dessus + bounce ✅ 2024-03-01
- [x] Equivalent plante carnivore qui sort du tuyau ✅ 2024-03-01

Je bloque un peu sur l'avancement, rechute de motivation mais j'essaie d'avancer un petit peu quand meme.

# 240302
- [x] La lave tue ✅ 2024-03-02
- [x] Renvoi au debut de scene lorsque le player meurt ✅ 2024-03-02

C'est pas optimise du tout. J'ai besoin de creer une classe qui va gerer le jeu et de m'en servir pour gerer les etats du joueur, je pense. Faut que je fasse le point sur tout ce qu'il reste a faire et que je l'organise d'une maniere un peu plus coherente plutot que d'avancer par-ci par-la comme si j'etais le Petit Poucet.

# 240327
Plus de 20 jours pour reprendre ! Enorme baisse de motivation, impossible de m'y remettre jusqu'a aujourd'hui. Et encore ce fut un petit avancement, et il reste 2 jours, compliqué...
- [x] Fix ennemi vertical (precedemment probleme avec le mouvement, il y avait un snapback au lieu d'une redescente plus "smooth", regle avec coroutine) ✅ 2024-03-27
- [x] Animation boite quand on tape avec la tete, crystal instancie (que physiquement pour l'instant, pas de logique d'ajout a un compteur) ✅ 2024-03-27

# 240328
Plus gros avancement aujourd'hui, j'ai implemente un GameManager pour stocker les ajouts d'item, qui me servira pour le life system si j'ai le temps de le faire aussi.
- [x] GameManager ✅ 2024-03-28
- [x] Classe abstraite ItemAbstract avec une methode abstraite Collect puis + tard methode virtuelle pour le son des items collectes ✅ 2024-03-28
- [x] Classe Crystal refaite, avec la methode Collect qui utilise le AddCrystal dans le GameManager ✅ 2024-03-28
- [x] Classe PlayerInteractions qui pour l'instant utilise la methode Collect dans le cas de collision trigger si l'objet est un item ✅ 2024-03-28

# 240329
Dernier jour, je viens de terminer le travail et il me reste moins de 12 heures pour rendre le devoir. Il me reste deux choses importantes a faire : un health system et une UI. Un peu depassee par le stress mais j'espere que ca va le faire. Je regrette evidemment de pas m'y etre prise plus tot meme si j'avais essaye a plusieurs reprises de m'y remettre.
Si vous lisez cette partie, je souhaite vous presenter mes excuses. J'espere ne pas donner l'impression que je n'ai pas pris au sérieux vos cours et vos enseignements. Le projet est intéressant et fun, bien que difficile a commencer, et difficile a continuer, mais c'est le cas pour beaucoup de choses me concernant.

10 heures plus tard, resultat :
- Systeme de vie implemente (pas dequivalent de Mario grand mario feu, juste 3 coeurs basiques)
- Menu : accueil du jeu, menu pause, game over. Avec tous les boutons necessaires.

A la place de reload la scene comme je faisais avant je remets a 0 les compteurs et reactive ce qui a ete desactive. Seul bemol les ennemis ne reaparaissent pas - j'ai essaye de check tout ce a quoi je pouvais penser mais rien. On est a moins de 2 heures du rendu et je suis levee depuis 5h30 donc je prefere rester la-dessus !
Je viens de me rendre compte que j'avais le meme probleme avec les cristaux ! Ca je m'en suis pas occupee donc c'est normal.
Je pense que j'aurais juste du rester sur le reload de la scene.