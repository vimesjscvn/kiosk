using System;

namespace DepartmentGroup.Domain.Models
{
    public class TimeActiveViewModel
    {
        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public TimeSpan? EndTimeActiveAM { get; set; }


        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        public TimeSpan? StartTimeActiveAM { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public TimeSpan? EndTimeActivePM { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        public TimeSpan? StartTimeActivePM { get; set; }
    }
}