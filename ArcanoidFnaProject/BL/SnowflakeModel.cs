using System;


namespace FnaProject.BL
{
    /// <summary>
    /// Слой бизнес-логики. Описывает математическую модель снежинки без привязки к графическому движку.
    /// </summary>
    public class SnowflakeModel
    {
        /// <summary>
        /// Текущее X-положение снежинки в пикселях.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Текущее Y-положение снежинки в пикселях.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Масштаб (размер) снежинки.
        /// </summary>
        public float Scale { get; private set; }

        /// <summary>
        /// Скорость падения снежинки в пикселях в секунду.
        /// </summary>
        public float Speed { get; private set; }

        private Random randomGenerator;

        /// <summary>
        /// Создаёт новую модель снежинки и выполняет её инициализацию.
        /// </summary>
        public SnowflakeModel(Random random, int screenWidth)
        {
            randomGenerator = random;
            Reset(screenWidth, true);
        }

        /// <summary>
        /// Обновляет состояние снежинки (позицию) в течение одного кадра.
        /// </summary>
        public void Update(float deltaTime, int screenWidth, int screenHeight)
        {
            Y += Speed * deltaTime;

            if (Y > screenHeight)
            {
                Reset(screenWidth, false);
            }
        }

        private void Reset(int screenWidth, bool isInitial)
        {
            var randomScale = (float)randomGenerator.NextDouble() * GlobalSettings.ScaleRange + GlobalSettings.MinScale;
            Scale = randomScale;
            Speed = Scale * GlobalSettings.SpeedMultiplier;

            X = randomGenerator.Next(0, screenWidth);
            Y = isInitial ? randomGenerator.Next(GlobalSettings.InitialSpawnVerticalOffset, 0) : GlobalSettings.ResetVerticalOffset;
        }
    }
}