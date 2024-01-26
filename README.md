# ``csharp-microservice`` 🌐

`csharp-microservice` is a project that demonstrates the use of microservices architecture in C#. 
It includes features like secure authentication, task management, and service-to-service communication through a gateway.

<img src="https://i.ibb.co/Z16WHMx/architecture.png" alt="architecture">

## ``Accounts``

In our application, there is two types of user :
1. ``Admin`` : can delete a user 
2. ``Basic`` : basic user (can only add/remove/update tasks)

### Admin
```
	username : admin
	password : 123
```

### Basic

````
	username : user1
	password : 123
````

## ``Features``

- ``Secure Authentication``: Implements JWT for secure access.
- ``Task Management``: Allows users to manage their tasks.
- ``Service Communication``: Uses a gateway for inter-service communication.
-----------------------------------------------------------------------------------------------------------

## 📅 Séance 2 

### 🖥️ Frontend
- Création d'une page d'inscription. ✅
- Modification du login pour intégrer la communication avec la gateway. ✅
- Intégration de la page d'inscription avec la gateway. ✅
- Développement d'une page pour afficher les tâches via le second microservice. ✅

### 🌉 Gateway
- Création de la route `register` pour l'enregistrement des utilisateurs. ✅
- Validation alphanumérique des identifiants et mots de passe. ✅
- Ajout d'un contrôleur pour le second microservice. ✅

## 📅 Séance 3

### 🖥️ Frontend
- Gestion du JWT lors du login et stockage dans le local storage. ✅
- Ajout du token JWT aux appels HTTP (à l'exception de login/register).
- Fonctionnalités pour lister, supprimer et mettre à jour les tâches. ✅

### 🌉 Gateway
- Intégration et gestion du JWT. ✅
- Ajout du JWT dans Swagger pour faciliter les tests API. ✅
- Sécurisation des routes avec le système d'authentification. ✅

### 📝 Microservice de Todo
- Filtre des tâches par utilisateur. ✅
- Création d'une classe `TodoDb` pour la gestion des tâches. ✅
- Configuration de `TodoDb` en tant que singleton dans `program.cs`. ✅

## 💡 Bonus
- Implémentation des rôles pour une gestion fine des accès. ✅
- Persistances des tâches dans une base de données après fermeture du ``TaskService`` ✅