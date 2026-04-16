namespace FnaProject
{
    /// <summary>
    /// Содержит все глобальные константы и параметры конфигурации скринсейвера.
    /// </summary>
    public static class GlobalSettings
    {
        /// <summary>
        /// Количество снежинок, отрисовываемых одновременно.
        /// </summary>
        public const int SnowflakeCount = 1000;

        /// <summary>
        /// Минимально возможный масштаб снежинки.
        /// </summary>
        public const float MinScale = 0.01f;

        /// <summary>
        /// Максимальный разброс масштаба снежинки.
        /// </summary>
        public const float ScaleRange = 0.05f;

        /// <summary>
        /// Множитель скорости падения снежинки относительно её размера.
        /// </summary>
        public const float SpeedMultiplier = 5000f;

        /// <summary>
        /// Начальный вертикальный разброс при первом запуске (в пикселях).
        /// </summary>
        public const int InitialSpawnVerticalOffset = -1080;

        /// <summary>
        /// Отступ выше экрана для перерождения снежинки (в пикселях).
        /// </summary>
        public const int ResetVerticalOffset = -100;

        /// <summary>
        /// Стандартная ширина экрана для инициализации.
        /// </summary>
        public const int DefaultWidth = 1920;

        /// <summary>
        /// Стандартная высота экрана для инициализации.
        /// </summary>
        public const int DefaultHeight = 1080;
    }
}