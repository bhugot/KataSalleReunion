# KataSalleReunion

On souhaite exposer une API pour réserver des salles de réunion.
Cette API permet de:
* Lister des salles
* Créer des réservations
* Supprimer des réservations
* En cas de conflit (de réservation), l’api doit proposer tous les créneaux libres de la journée demandée.

 
Pour simplifier au maximum l’exercice
 
1) il y a 10 salles ( « room0 » … « room9 » )
2) une réservation est
*          Au nom d’une seule personne ( paramètre « user » )
*          Concerne toujours une seule salle ( paramètre « room »)
*          Sur un créneau début / fin - la journée est découpée en créneaux d’1 heure (24 créneaux donc)
*          Jamais sur plusieurs jours

3) le back-end n’a pas d’importance, peut-être in-memory par exemple. Mais fonctionnellement, vous devez gérer les conflits (donc maintenir un état) – cf ci-dessus

Le but de ce kata est de montrer
* Votre approche de modélisation « restful » de cette API (url paths, status codes …)
* Votre maitrise d’asp.net webapi (owin, etc.) – vous pouvez hoster dans IIS ou en self-hosted, peu importe
* Bonus : incorporer https://www.nuget.org/packages/Swashbuckle/5.3.2 pour exposer le swagger de cette API et interagir avec dynamiquement (« try out »).