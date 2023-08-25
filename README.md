# Microservices-Directory kullanılan microservislerin ve yapılanların  açıklamaları

#### Directory microservice ; 
    * Rehberdedki kişilerin ve ileşim bilgilerinin oluşturduğu katmandır
    * ASP.NET Core Web API kullanıldı
    * Üç farklı aktman blulnmaktadır Api,Business,Entities
      * Api: endpointlerin bulunduğu katman
      * Business :lojik işlemlerin yapldığı katman
      * Entities :kullanılan entity ve dtoların bulunduğu katman
    * **MongoDB database** kullanıldı
    * Swagger Open API kullanıldı


 #### Report microservice ; 
    * Raporların oluştulduğu ve message queue (Azureservisbus) sistemin tetiklendiği katmandır  
    * ASP.NET Core Web API kullanıldı 
    * Üç farklı aktman blulnmaktadır Api,Business,Entities
    * Api: endpointlerin bulunduğu katman
    * Business :lojik işlemlerin yapldığı katman
    * Entities :kullanılan entity ve dtoların bulunduğu katman
    * **MongoDB database** kullanıldı
    *  **Azure servis bus**(Producer) kullanıldı
    * Swagger Open API kullanıldı


  #### Identity microservice ; 
    * Diğer  microservicelere erişim sağlamak için kullanılan servistir
    * ASP.NET Core Web API kullanıldı 
    * Jwt token üretiyor
    * Swagger Open API kullanıldı


  #### Consumer service ; 
    * Üretilen message queuelerin burda dinlemsi ve gerekli aksinyonların alınması için kullanılır 
    * Console application kullanıldı 
    * **Azure servis bus**(Consumer) kullanıldı


  #### Gateway service  ; 
    * Kullanılan microservicelerin tek bir host olarak kullanılamsın sağlar 
    * ASP.NET Core Web API kullanıldı  
    * **Ocelot** kullanıldı
    * Şuan projede kullanılmıyor ama isteniliğinde kullanılabilir
  
   #### Shared Core Katman  ; 
       * Tüm servislerin kullandığı araçalarının buluduğu katmandır 

   #### Not  ; 
       * Projeyi çalıştırmak için tum  servis ayağa kaldırmaknız yeterli olacaktır .Tüm konfigürasyon aktif (mongodb,azurservisbus).
       *Şuanda tüm authenticationalar devre dışı test etmeyi kolaylaştırmak için








