﻿namespace MoonGameRev.Common
{
    public static class EntityValidationConstants
    {
        public static class Review
        {
            public const double ReviewMaxRange = 10.00;
            public const double ReviewMinRange = 1.00;

            public const int CommentMaxLength = 500;
            public const int CommentMinLength = 20;
            public const int ProsAndConsMinLength = 3;
        }

        public static class Game
        {
            public const int TitleMaxLength = 100;
            public const int TitleMinLength = 3;

            public const int DeveloperNameMaxLength = 100;
            public const int DeveloperNameMinLength = 5;

            public const int PublisherNameMaxLength = 100;
            public const int PublisherNameMinLength = 5;

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;

            public const int GameSiteMaxLength = 2048;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Genre
        {
            public const int GenreNameMaxLength = 50;
            public const int GenreNameMinLength = 5;
        }

        public static class Journalist
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class News
        {
            public const int TitleMaxLength = 70;
            public const int TitleMinLength = 3;

            public const int ArticleMinLength = 100;
            public const int ArticleMaxLength = 2500;

            public const int PictureUrlMaxLength = 2048;
        }

        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int UserNameMinLength = 3;
            public const int UserNameMaxLength = 33;
        }
    }
}
