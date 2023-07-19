1: Solution is written in Clean Architecture, application layer is the core component and DI is heavily used, also complies with design principles like single responsibility, separate of concern, persistence ignorance and DRY(do not repeat yourself)<br/><br/>
2: Uses a static class to work as mocked DB for simplicity, but code is structured for flexibility and scalability, it can easily swap to other data source, like a real database <br/><br/>
3: Unit tests are provided for both API and front end, but only basic ones for demo purpose<br/><br/>
4: Basic validations added using built in annotation, for the same reason<br/><br/>
5: include .env file in react, please change the API URL when test on you own computer
