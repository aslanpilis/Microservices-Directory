# Microservices-Directory kullanılan micro servislerin ve yapılanlrın  açıklamaları
#### Directory microservice ; 
* ASP.NET Core Web API kullanıldı
  Rehberdedki kişilerin ve ileşim bilgilerinin oluşturduğu katmandır
* Üç farklı aktman blulnmaktadır Api,Business,Entities
   * Api: endpointlerin bulunduğu katman
   * Business :lojik işlemlerin yapldığı katman
   * Entities :kullanılan entity ve dtoların bulunduğu katman
* **MongoDB database** kullanıldı
* Swagger Open API kullanıldı


 #### Report microservice ; 
 Raporların oluştulduğu ve message queue (Azureservisbus) sistemin tetiklendiği katmandır  
* ASP.NET Core Web API kullanıldı 
* Üç farklı aktman blulnmaktadır Api,Business,Entities
   * Api: endpointlerin bulunduğu katman
   * Business :lojik işlemlerin yapldığı katman
   * Entities :kullanılan entity ve dtoların bulunduğu katman
* **MongoDB database** kullanıldı
*  **Azure servis bus**(Producer) kullanıldı
* Swagger Open API kullanıldı


*  #### Identity microservice ; 
 Diğer  microservicelere erişim sağlamak için kullanılan servistir
* ASP.NET Core Web API kullanıldı 
* Jwt token üretiyor
* Swagger Open API kullanıldı


*  #### Consumer service ; 
Üretilen message queuelerin burda dinlemsi ve gerekli aksinyonların alınması için kullanılır 
* Console application kullanıldı 
* **Azure servis bus**(Consumer) kullanıldı


*  #### Gateway service  ; 
 Kullanılan microservicelerin tek bir host olarak kullanılamsın sağlar 
* ASP.NET Core Web API kullanıldı  
* **Ocelot** kullanıldı
* Şuan projede kullanılmıyor ama isteniliğinde kullanılabilir
  
*  #### Shared Core Katman  ; 
 Tüm servislerin kullandığı araçalrının buluduğu katmandır 









