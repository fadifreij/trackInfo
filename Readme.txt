1- Please check server name from appsettngs.json from SearchEngine solution and SearchEngine.Model 
2- once you want to add a new engine it should start with https:// and end with /    .
3- To migrate database :

from Package manager console :

dotnet ef migrations add initial 

dontnet ef database update



 