using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedWebsite.Models
{
    /// <summary>
    /// Generic course lesson
    /// </summary>
    public abstract class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    /// <summary>
    /// Video lecture lesson
    /// </summary>
    public class VideoLesson : Lesson
    {
        /// <summary>
        /// EmbedCode for video
        /// </summary>
        public string EmbedCode { get; set; }
    }
}
