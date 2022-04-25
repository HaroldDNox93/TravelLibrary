
CREATE TABLE autores(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre VARCHAR(45) NOT NULL,
	apellidos VARCHAR(45) NOT NULL
);
INSERT INTO autores (nombre, apellidos) VALUES
	('William','Faulkner'),
	('Oscar','Wilde'),
	('Franz','Kafka'),
	('William','Shakespeare'),
	('Gabriel','Garcia Marquez'),
	('James','Joyce');

CREATE TABLE editoriales(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre VARCHAR(45) NOT NULL,
	sede VARCHAR(45) NOT NULL
);
INSERT INTO editoriales (nombre, sede) VALUES
	('Editorial A1','Sede A'),
	('Editorial A2','Sede A'),
	('Editorial B1','Sede B'),
	('Editorial C1','Sede C'),
	('Editorial D1','Sede D');

CREATE TABLE libros(
	isbn INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	titulo VARCHAR(45) NOT NULL,
	sinopsis TEXT NOT NULL,
	n_paginas VARCHAR(45) NOT NULL,
	editorial_id INT NOT NULL,
	FOREIGN KEY(editorial_id) REFERENCES editoriales(id)
);
INSERT INTO libros (titulo, sinopsis, n_paginas, editorial_id) VALUES
	('El sonido y la furia','Novela clave en la obra de William Faulkner (1897-1962), ya que en ella consolidó el que habría de ser su mundo narrativo, "El ruido y la furia" (1929) -título que evoca los célebres versos de "Macbeth"- se articula en torno a los monólogos interiores de los hermanos Compson: Benjy, el idiota; el sensible Quentin, atormentado por el incestuoso amor que siente hacia su hermana Caddy, y el inescrupuloso Jason. La trágica historia que Faulkner va urdiendo con genial maestría en torno a los miembros de una antigua familia hacendada del Sur, desvela con una fuerza expresiva inusual la lenta e implacable corrosión del tiempo, así como el desvanecimiento y la perversión del intangible paraíso de la infancia.','392', 1),
	('Mientras agonizo','Es un orgullo presentar la versión definitiva de "Mientras agonizo", fijada en 1985, a partir de las galeradas originales, compulsadas con el manuscrito autógrafo y la copia mecanografiada por el propio autor. Quinta novela de William Faulkner, "Mientras agonizo" es una de sus obras maestras y uno de los libros por los que sentía más aprecio. Lo escribió, según él mismo explicaba, en seis frenéticas semanas, de madrugada, mientras trabajaba como bombero y vigilante nocturno de la central eléctrica de la universidad de Mississippi. Relata la peripecia de una familia de blancos pobres, los Bundren, que recorren los parajes rurales del Sur con el cadáver de la esposa y madre en un ataúd para enterrarla en una parcela de su propiedad. Esta aventura tragicómica, en la que se entremezcla un humor de tintes ácidos con la más arrolladora desolación, está narrada mediante una sucesión de monólogos interiores de los diversos personajes: el patriarca familiar, los hijos y la propia muerta, que habla al lector desde «el otro lado», desde el más allá. Y en este viaje con ecos grotescos de la Odisea homérica y de episodios bíblicos, Faulkner introduce los temas y obsesiones que fecundan su literatura: la decadencia del Sur, el viaje iniciático, la culpa que atormenta a los personajes, la transgresión y su castigo, el peso opresivo del pasado.','248',1),
	('El retrato de Dorian Gray','Basil Hallward es un artista que queda fuertemente impresionado por la belleza estética de un joven llamado Dorian Gray y comienza a admirarlo. Basil pinta un retrato del joven. Charlando en el jardín de Hallward, Dorian conoce a un amigo de Basil y empieza a cautivarse por la visión del mundo de Lord Henry.', '277', 3),
	('El proceso','Posiblemente algún desconocido había calumniado a Josef K., pues sin que éste hubiese hecho nada punible, fue detenido una mañana. Al filo de la muerte, Franz Kafka pidió a su amigo Max Brod que destruyese todo el material que no había publicado en vida para que nunca viese la luz', '296', 4),
	('La Metamorfosis','La metamorfosis es un relato dividido en tres partes, donde se narra la transformación de Gregorio Samsa, un viajante de comercio de telas, en un monstruoso insecto, y el impacto que tendrá este acontecimiento no solo en su vida, sino en la de su familia.', '96', 4),
	('Hamlet','La obra transcurre en Dinamarca, y trata de los acontecimientos posteriores al asesinato del rey Hamlet (padre del príncipe Hamlet), a manos de su hermano Claudio. El fantasma del rey pide a su hijo que se vengue de su asesino.', '720', 2),
	('Romeo y Julieta','En Verona, dos jóvenes enamorados, de dos familias enemigas, son víctimas de una situación de odio y violencia que ni desean ni pueden remediar. En una de esas tardes de verano en que el calor «inflama la sangre», Romeo, recién casado en secreto con su amada Julieta, mata al primo de ésta.', '176', 5),
	('Macbeth','Amparado en las engañosas profecías de las Hermanas Fatídicas, brujas o diosas del destino, Macbeth decide asesinar a su rey y tomar la corona. Consciente del horror al que se entrega, forja su terrible destino y se deja poseer por el mal que nace del ansia de poder, creyéndose invencible y eterno.', '160', 1),
	('Cien Años de Soledad','Entre la boda de José Arcadio Buendía con Amelia Iguarán hasta la maldición de Aureliano Babilonia transcurre todo un siglo. Cien años de soledad para una estirpe única, fantástica, capaz de fundar una ciudad tan especial como Macondo y de engendrar niños con cola de cerdo.', '471', 4),
	('Del amor y otros demonios','Del amor y otros demonios es una novela del escritor colombiano Gabriel García Márquez y publicada en el año 1994. La novela relata la historia de una pequeñita niña llamada Sierva María, la cual ha sufrido una serie de calvarios a lo largo de su corta vida.', '168', 3),
	('El amor en los tiempos del cólera','Florentino Ariza y Fermina Daza se enamoran apasionadamente, pero Fermina eventualmente decide casarse con un médico rico y de muy buena familia. Florentino está anonadado, pero es un romántico.', '442', 3),
	('Crónica de una muerte anunciada','Crónica de una muerte anunciada relata la historia del asesinato de Santiago Nasar, un joven de 21 años, con ascendencia árabe y católico, quien gobernaba la hacienda de su difunto padre y estaba comprometido con Flora Miguel. A continuación, presentamos un resumen cronológico de la historia.', '128', 2),
	('Ulises','Sin sinopsis.', '1000', 3),
	('Eveline','Basado en hechos reales, Evelyn relata la emocionante historia del Desmond Doyle y sus hijos menores Evelyn, Maurice y Dermot. Luchando para criar a sus hijos solo en la Irlanda de 1953, Doyle se siente desolado cuando el poder de la Iglesia y los Tribunales irlandeses le quitan a sus hijos y los internan en orfanatos..', '172', 1);

CREATE TABLE autores_has_libros(
	autor_id INT NOT NULL,
	libro_isbn INT NOT NULL,
	FOREIGN KEY(autor_id) REFERENCES autores(id),
	FOREIGN KEY(libro_isbn) REFERENCES libros(isbn)
);
INSERT INTO autores_has_libros (libro_isbn, autor_id) VALUES
	(1, 1),
	(2, 1),
	(3, 2),
	(4, 3),
	(5, 3),
	(6, 4),
	(7, 4),
	(8, 4),
	(9, 5),
	(10, 5),
	(11, 5),
	(12, 5),
	(13, 6),
	(14, 6);