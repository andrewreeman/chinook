﻿namespace Chinook.Catalog.Domain.Models
{
    public sealed class Composition
    {
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public int TrackId { get; set; }
        public Track? Track { get; set; }
    }
}
