

public class K {

    public class Player {
        // Player variables
        public static float MoveSpeed = 5f;
        public static float FireRate = .2f;
    }

    public class Enemy {
        public static float MoveSpeed = 4f;
        public static float FireRate = 1.2f;
        public static float FireVar = .4f;
        public static float FireMin = .2f;

        public class Spawn {
            public static float TimeBetween = 1.2f;
            public static float TimeVariance = 0.5f;
            public static float TimeMinimum = 0.2f;
        }

        public class Wave {
            public static float TimeBetween = 0f;
        }
    }

    public class Projectile {
        public static float Speed = 8f;
        public static float Life = 5f;
    }

    public class GamePlay {
        
    }

    public class Screen {

        public class Padding {
            public static float Left = 0.7f;
            public static float Right = 0.7f;
            public static float Top = 12f;
            public static float Bottom = 2f;
        }
    }

}

