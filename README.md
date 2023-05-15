## Fruityvice API .NET Core Web API

This solution demonstrates the use of a Service layer to retrieve and manipulate data from the Fruityvice API. 
The Service layer is implemented as an interface and a concrete implementation, which communicates with the Fruityvice API using an API client.

### Implementation
    #### Service Layer
        The Service layer is responsible for handling all business logic related to retrieving and manipulating data. 
        It consists of an interface and a concrete implementation, which communicate with the API client to fetch and manipulate data.

    #### API Client
        The API client is responsible for calling the Fruityvice API and deserializing the response into a collection of Fruit objects. 
        I have used the HttpClientFactory to create a single instance of the HttpClient, which can be reused across multiple requests. 
        It is used by the Service layer to fetch data from the Fruityvice API.

    #### SOLID Principles
        I have followed the SOLID principles to ensure that our code is easy to maintain, test, and extend. In particular, I have used the Dependency Inversion Principle (DIP) to ensure that our Service layer depends only on abstractions and not on concrete implementations. 
        This makes our code more modular and easier to test.

    #### Configuration
        To configure our application, I have used an appsettings.json file that stores configuration information such as the BaseUrl for the Fruityvice API. 
        I have also used the ConfigurationBuilder to read these settings at runtime.

    #### Benefits
        This approach ensures that our code is maintainable, testable, and scalable. It follows best practices for designing web APIs, such as using a Service layer to separate business logic from data access and using HttpClientFactory to manage the lifetime of HttpClient instances.


### API Endpoints

    GET /api/fruits
    Returns a list of all fruits.

    POST /api/fruits/family
    Returns a list of all fruits belonging to a fruit family.

        Request Body
        The request body should be in JSON format and include the following property:
        Example Request :

        {
            "fruitFamily": "Rutaceae"
        }

        Example Response :

        [
           {
              "genus":"Citrus",
              "name":"Orange",
              "id":12,
              "family":"Rutaceae",
              "order":"Sapindales",
              "nutritions":{
                 "carbohydrates":12.5,
                 "protein":0.9,
                 "fat":0.2,
                 "calories":47,
                 "sugar":9.35
              }
           },
           {
              "genus":"Citrus",
              "name":"Lemon",
              "id":13,
              "family":"Rutaceae",
              "order":"Sapindales",
              "nutritions":{
                 "carbohydrates":9.32,
                 "protein":1.1,
                 "fat":0.3,
                 "calories":29,
                 "sugar":2.5
              }
           }
        ]

