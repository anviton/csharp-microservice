# ``csharp-microservice``

## ``Séance 2``

### Sur le front:
- Créer une page d'inscription - OK
- Modifier le login pour que le front communique avec la gateway et appel la route de login
- Faire que la page d'inscription appel la gateway
- Faire une page pour afficher un visuel de votre second micro service (liste de tâches)

### Sur la gateway:
- Créer la route register pour le user - OK
- Vérifier que le user / pass ne comporte que des caractères alphanumériques - OK
- Ajouter un controller pour le second micro service qui relaie les appels - OK

## ``Séance 3``

### Sur le front:
- Récupérer le JWT lors du login et le stocker dans le local storage
- Ajouter le token JWT aux appels HTTP autre que login / register
- Pouvoir lister les todo de l'utilisateur connecté (EN COURS - reynalde)
- Pouvoir supprimer un todo (EN COURS - reynalde)
- Pouvoir mettre à jour un todo (EN COURS - reynalde)

### Sur la gateway:
- Ajouter la gestion du JWT
- Ajouter le JWT au swagger
- Rendre certaines routes [Authorized]
- Récupérer l'id de l'utilisateur sur les routes authentifiées
- Transmettre l'id au micro service todo pour ne récupérer que les données concernant notre utilisateur

### Sur le micro service todo:
- Ne renvoyer que les todo de notre utilisateur
- Créer une classe TodoDb qui contiendra la liste des todos - OK
- Ajouter la classe TodoDb dans le program.cs en tant que singleton - OK
- Utiliser cette classe dans le service todo - OK

Vous aurez besoin de ces packages pour utiliser le JWT - OK
