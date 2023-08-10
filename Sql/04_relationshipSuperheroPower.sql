CREATE TABLE SuperHeroPower(
	SuperHeroId INT,
	PowerId INT,
	PRIMARY KEY(SuperHeroId, PowerId),
	FOREIGN KEY (SuperHeroId) References SuperHero(id),
	FOREIGN KEY (PowerId) References Power(id)
);