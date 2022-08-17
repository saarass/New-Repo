using ProjectRoseOfSharon.Business.Migration;

namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Het terrein dat uit woestijn, bos en gras tiles bestaat, en waarop de 
    /// herders en dieren verblijven.
    /// </summary>
    public class Terrain
    {
        /// <summary>
        /// De huidige iteratie (stap in de simulatie)
        /// </summary>
        public int Iteration { get; private set; }
        
        /// <summary>
        /// De configuratie van het terrein.
        /// </summary>
        public TerrainConfig TerrainConfig { get; set; }

        /// <summary>
        /// De configuratie van een koe (nodig om koeien te kunnen instantieren).
        /// </summary>
		public CowConfig CowConfig { get; }

        /// <summary>
        /// De configuratie van een geut (nodig om geiten te kunnen instantieren).
        /// </summary>
		public GoatConfig GoatConfig { get; }

        /// <summary>
        /// De configuratie van een desert spot (nodig om desert spots te kunnen instantieren).
        /// </summary>
		public DesertConfig DesertConfig { get; }

        /// <summary>
        /// De configuratie van een grass spot (nodig om grass spots te kunnen instantieren).
        /// </summary>
		public GrassConfig GrassConfig { get; }

        /// <summary>
        /// De configuratie van een forest spot (nodig om forest spots te kunnen instantieren).
        /// </summary>
		public ForestConfig ForestConfig { get; }
        
        /// <summary>
        /// De spots op dit terrein. Twee dimensionale array, waarbij de eerste index de x 
        /// waarde, en de tweede index de y waarde is van de positie van de spot.
        /// </summary>
		public ISpot[,] Spots { get; private set; }

        /// <summary>
        /// Om random dingen te kunnen doen.
        /// </summary>
        private readonly Random Dice;

        /// <summary>
        /// De breedte van het terrein, oftewel het aantal spots in de breedte. Shortcut naar TerrainConfig.Width.
        /// </summary>
        public int Width => TerrainConfig.Width;

        /// <summary>
        /// De hoogte van het terrein, oftewel het aantal spots in de hoogte. Shortcut naar TerrainConfig.Height.
        /// </summary>
        public int Height => TerrainConfig.Height;

        /// <summary>
        /// De biologicals op dit terrein. 
        /// </summary>
        public List<IBiological> Biologicals { get; } = new List<IBiological>();

        public Terrain(TerrainConfig terrainConfig, CowConfig cowConfig, GoatConfig goatConfig, DesertConfig desertConfig, GrassConfig grassConfig, ForestConfig forestConfig)
        {
            TerrainConfig = terrainConfig;
			CowConfig = cowConfig;
			GoatConfig = goatConfig;
			DesertConfig = desertConfig;
			GrassConfig = grassConfig;
			ForestConfig = forestConfig;
			Spots = new ISpot[TerrainConfig.Width, TerrainConfig.Height];
            Dice = new Random();
            InitTerrain();
        }

        /// <summary>
        /// Initialiseert het terrein met een begin situatie.
        /// </summary>
        public void InitTerrain()
        {
            for(int x = 0; x<TerrainConfig.Width; x++)
            {
                for (int y = 0; y < TerrainConfig.Height; y++)
                {
                    CreateDesertSpot(x, y);

                    // in plaats hiervan, als je ook grass spots hebt, kun je de volgende code gebruiken om een wat meer 
                    // random terrein te genereren:
                    // var next = Dice.NextDouble();

                    // if(next > .1)
					// {
                    //    CreateDesertSpot(x, y);
                    //}
                    //else
					//{
                    //    CreateGrassSpot(x, y);
                    //}
                }
            }
        }

        /// <summary>
        /// Creeert alle biologicals op dit terrein.
        /// </summary>
        public void SpawnBiologicals()
        {
            ISpot spot = Spots[Height / 2, Width / 2];
            Shepherd<IAnimal> shepherd = new Shepherd<IAnimal>(new Group<IAnimal>(), spot);

            // Toetsdeel C: als je herds, droves, cows, goats, etc gemaakt hebt, kun je met onderstaande code 2 kuddes genereren:
			//ISpot spot = Spots[Dice.Next(Width), Dice.Next(Height)];
			//Herd herd = new Herd(spot, CowConfig);
			//herd.Shepherd.MigrationStrategy = new ClockwiseMigrationStrategy();

            //spot = Spots[Dice.Next(Width), Dice.Next(Height)];
            //Drove drove = new Drove(spot, GoatConfig);
            //drove.Shepherd.MigrationStrategy = new MaxSpotsMigrationStrategy();
        }

        /// <summary>
        /// Reset dit terrein door de spots en de biologicals opnieuwe te genereren.
        /// </summary>
        public void Reset()
		{
            Spots = new ISpot[TerrainConfig.Width, TerrainConfig.Height];
            Biologicals.Clear();
            InitTerrain();
            SpawnBiologicals();
        }

        /// <summary>
        /// Retourneert de spot op de gegeven positie.
        /// </summary>
        public ISpot GetSpot(Position position)
        {
            return GetSpot(position.X, position.Y);
        }

        /// <summary>
        /// Retourneert de spot op de gegeven positie (x en y waarde).
        /// </summary>
        public ISpot GetSpot(int x, int y)
        {
            return Spots[x, y];
        }

        /// <summary>
        /// Creeert een desert spot op de gegeven positie.
        /// </summary>
        public void CreateDesertSpot(int x, int y)
		{
            CreateDesertSpot(new Position(x, y));
        }

        /// <summary>
        /// Creeert een desert spot op de gegeven positie.
        /// </summary>
        public void CreateDesertSpot(Position pos)
        {
            Spots[pos.X, pos.Y] = new DesertSpot(DesertConfig, this, pos);
        }

        /// <summary>
        /// Of de gegeven positie buiten het kaders van dit terrein is.
        /// </summary>
        public bool IsOutOfBounds(Position pos)
		{
            return pos.X < 0 || pos.X >= TerrainConfig.Width 
                || pos.Y < 0 || pos.Y >= TerrainConfig.Height;
        }

        /// <summary>
        /// Retourneert alle bestaande spots binnen een straal van viewrange vanaf de gegeven spot, oplopend gesorteerd op afstand.
        /// Het resultaat is een half-fabrikaat bedoeld voor verder bewerking, voeg bij gebruik in ieder geval op enig moment een ToList() of ToArray() toe.
        /// </summary>
        /// <param name="spot">het punt vanaf waar gekeken wordt</param>
        /// <param name="viewRange">de straal waar punten binnen moeten vallen</param>
        /// <returns>Een IEnumerable van gevonden punten op volgorde van afstand vanaf de gegeven Spot</returns>
        public IEnumerable<ISpot> GetSpotsInRange(ISpot spot, int viewRange)
        {
            int x = spot.Position.X;
            int y = spot.Position.Y;
            // by randomizing the directions we're iterating through,
            // we get a more diffuse pattern of movement. Else, things
            // would primarily move in the direction that is always inspected first.
            List<int> dxs = new int[] { -1, 0, 1 }.OrderBy(x => Dice.Next()).ToList();
            List<int> dys = new int[] { -1, 0, 1 }.OrderBy(x => Dice.Next()).ToList();

            for (int range = 1; range < viewRange; range++)
            {
                foreach (int dx in dxs)
                {
                    foreach (int dy in dys)
                    {
                        Position pos = new Position(x + dx * range, y + dy * range);

                        if (!(dx == 0 && dy == 0) && !IsOutOfBounds(pos))
                        {
                            yield return GetSpot(pos);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Roept Update() aan op alle Biologicals op dit terrein, en hoogt <see cref="Iteration"/> op met 1.
        /// </summary>
        public void Update()
        {
            foreach(var biological in Biologicals)
            {
                biological.Update();
            }

            foreach(ISpot spot in Spots)
			{
                spot.Update();
			}

            Iteration++;
        }

    }
}
