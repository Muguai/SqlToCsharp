ALTER TABLE Assistant
ADD SuperHeroId int

ALTER TABLE Assistant
ADD CONSTRAINT fk_Assistant_SuperHero
FOREIGN KEY (SuperHeroId) References SuperHero(id)