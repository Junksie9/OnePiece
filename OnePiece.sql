CREATE DATABASE  IF NOT EXISTS `onepiece` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `onepiece`;
-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: onepiece
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `arcos`
--

DROP TABLE IF EXISTS `arcos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `arcos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NombreArco` varchar(600) NOT NULL,
  `Descripcion` varchar(600) NOT NULL,
  `NumArco` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `arcos`
--

LOCK TABLES `arcos` WRITE;
/*!40000 ALTER TABLE `arcos` DISABLE KEYS */;
INSERT INTO `arcos` VALUES (2,'Alabasta','Luffy y su equipo continúan buscando el One Piece, convencidos de que el joven puede convertirse en el Rey Pirata. Sin embargo, deben ayudar a Nefertari Vivi a llegar a su tierra natal antes de que comience una guerra. El problema es que una organización maliciosa hará cualquier cosa para evitar que Luffy y sus amigos lleguen a Alabastro.',2),(3,'Skypiea','Los Sombreros de Paja continúan su aventura. Sin embargo, Luffy y los demás se enfrentan a una tierra llena de misterios e involucrados en una guerra que puede destruir a Skypiea de inmediato. Este es uno de los arcos que ya comienza con rellenos justo al comienzo de la saga.',3),(4,'Water 7','También conocida por Saga Enies Lobby o Saga CP9. Esta vez, los piratas ya están en mar abierto nuevamente y enfrentarán algunos peligros en su búsqueda para encontrar el One Piece. Uno de ellos es el tramposo Foxy, además de uno de los tres Miradores de la Armada, llamado Aokiji. Luffy necesita llegar al Agua 7 para encontrar un carpintero que se una a su tripulación y repare su nave.',4),(5,'East Blue','Comenzamos con la saga que introdujo a Luffy en el mundo, la llamada Saga East Blue. Muestra al personaje como un niño que vive en East Blue y al comienzo de reclutar a la tripulación para cazar el One Piece e intentar convertirse en el Rey Pirata.',1),(11,'arcodeprueba','prueba',10);
/*!40000 ALTER TABLE `arcos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capitulos`
--

DROP TABLE IF EXISTS `capitulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `capitulos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idArco` int NOT NULL,
  `NombreCapitulo` varchar(600) NOT NULL,
  `Descripcion` varchar(600) NOT NULL,
  `NumCap` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idArco` (`idArco`),
  CONSTRAINT `capitulos_ibfk_1` FOREIGN KEY (`idArco`) REFERENCES `arcos` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capitulos`
--

LOCK TABLES `capitulos` WRITE;
/*!40000 ALTER TABLE `capitulos` DISABLE KEYS */;
INSERT INTO `capitulos` VALUES (6,4,'¡Gran aventura en Long Ring Long Land!','Luego de escapar de la fortaleza de Navarone, los Sombrero de Paja llegan a una isla donde toda la flora y la fauna es alargada.',207),(7,2,'¡La primera fortaleza Aparece Laboon, la ballena gigante!','Luego de su alocada entrada al Grand Line, los Sombrero de Paja se topan con una pared enorme. Esta pared resulta ser Laboon, una ballena gigante que es cuidada por un extraño anciano desde hace años. ',62),(9,3,' ¡Zenny de la Isla de las Cabras y el barco pirata dentro de la montaña!','Luffy y compañía prosiguen con su viaje por el Grand Line y esta vez llegan a una isla desconocida y que parece estar desierta. Poco después descubren que está llena de cabras y que también hay un anciano.',136),(20,5,'¡Soy Luffy! ¡El hombre que se convertirá en el Rey de los Piratas!','Comienzan las andanzas de Monkey D. Luffy, un joven de goma que afirma que se convertirá en el Rey de los Piratas. Conoce a Coby por accidente durante el asalto de la pirata Alvida y huyen juntos.',1),(21,5,' ¡Aparece el gran espadachín! El Cazador de Piratas, Roronoa Zoro','Luffy, en su empeño por conseguir miembros para su tripulación, se entera de que un gran espadachín llamado Roronoa Zoro está preso en la base de la Marina y se propone liberarlo para que se una a él, pero el capitán Morgan no lo quiere permitir.',2),(22,5,'¡Morgan contra Luffy, Quién es esa belleza misteriosa!','En este episodio, veremos el breve pero intenso enfrentamiento de Luffy y Zoro contra el capitán Morgan. También tendrán que hacer frente a las argucias de su hijo, Helmeppo',3),(23,2,'¡Una promesa entre hombres! Luffy y la ballena prometen verse de nuevo','Una vez que Crocus le cuenta a Luffy y la tripulación la historia de Laboon, Luffy decide hacer una promesa con la ballena para que deje de golpearse contra el Grand Line. Luego, conocen a un grupo de extraños que los llevará a su próximo destino. ',63),(24,2,'¡Una ciudad que recibe a los piratas, Llegada a Whisky Peak!','Luego de sufrir las inclemencias del loco clima del Grand Line, los Sombrero de Paja llegan a Wisky Peak, donde son recibidos como héroes.',64),(25,3,'¡Cómo haces el dinero?, La ambición del prestamista Zenny!','El anciano, que se llama Zenny, les cuenta a los Sombrero de Paja a qué se dedicaba antiguamente y les dice que su sueño siempre fue ser un pirata. Por otro lado, un sargento de la Marina busca a Zenny porque cree que tiene un gran tesoro oculto.',137),(26,3,'¡La ubicación del tesoro de la isla! ¡Los piratas de Zenny salen al ataque!','Minchy, el sargento de la Marina ha iniciado el ataque a la isla para quedarse con el tesoro de Zenny, pero este no está dispuesto a ceder, así que luchará duramente contra Minchy para defender su sueño.',138),(27,4,'¡Un Davy Back contra los piratas Foxy!','Luffy y su tripulación conocen a un extraño anciano de la isla quien le cuenta su historia a la tripulación. Mientras Luffy y compañía intentaban ayudar al anciano para que regresara con sus compañeros, un grupo de pirata llega a la isla a desafiar a los Sombrero de Paja al Davy Back Fight, un juego de piratas en el que el premio son los miembros de la tripulación e incluso la bandera pirata del barco.',208),(28,4,'¡Primer asalto! Una vuelta de la Donut Race','Empieza el Davy Back Fight. En la primera ronda habrá una alocada carrera de botes hechos con barriles, donde la tripulación de Foxy usará toda clase de trucos sucios para ganar',209),(29,11,'pruebasinfoto','pruebasinfoto',2000),(30,11,'pruebaconfoto','pruebaconfoto',2001);
/*!40000 ALTER TABLE `capitulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NombreUsuario` varchar(45) NOT NULL,
  `Password` varchar(130) NOT NULL,
  `Rol` varchar(45) NOT NULL,
  `NombreReal` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'David','2E24EDAE4EF3053CD998B0306F4055A2920331C7D707FF20EF23C45E5282EA576D99ADC6FBD8E49E9B1B01C14BCE5E7BEA3D3B749890BC84237B49FCF5F1B77F','Administrador','Jesus David Flores Hernandez'),(2,'Jacob','00C7AC80A7D67B4E680163AED6A919AC8DD9940FE501F811BD27007CAA8378091AB1834A2524AE454586BDE3E6BC4B2A9EFEF0DA4D4D46D2458D9303D2A0A927','Supervisor','Jacob Asael Barrera Mata'),(3,'Erika','A79FE100836CBBB598ABFF21DE145E2CD7D77EFD7FE29538A494730AA4336C8D0345ED113A1D653DEDF694B15426639FAD46BB68C5596917D57EA2D499CDBBAA','Supervisor','Erika Yazmin Briones Gordillo');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-09 13:38:06
