# Explication des diagrammes

## Diagramme de données

Le modèle repose sur le fait qu'un mot de passe peut être partagé par plusieurs personne. Nous avons donc des *Entry* qui appartiennent à un *User* (utilisateur). Le *User* connait son détenteur. Les autres *User* qui connaissent le mot de passe ne pourront ni l'éditer, ni le repartager à nouveau.

[MCD](database_mcd.mermaid.md)

## Diagramme de classe

#### Les entrées
Les *Entry* représente donc chaque entrée dans l'application. Elle contient un *unique identifier*, le *Password* qu'on enregistre, un *Label*, l'*Url* du site dont on enregistre le mot de passe, et une *Note* pour des détails supplémentaires.

*Entry* est abstrait car on va différencier, via les filles *ProprietaryEntry* et *SharedEntry* si l'entrée nous appartient ou si c'est une entrée partagée avec nous. Une entrée ne peut pas être partagée ou éditer par une personne autre que le propriétaire.

Enfin, il y a une 

#### Les utilisateurs
Les utilisateur ont aussi besoin d'une abstraction, car on doit là aussi faire la différence entre un *User* qui peut être édité, et un *Sharer* qui ne donne accès qu'à son mail.


[Diagramme de classe](v2.mermaid.md)