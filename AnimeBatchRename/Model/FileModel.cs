// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using AnimeBatchRename.Extension;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnimeBatchRename.Model {
	/// <summary>
	/// Represents the file model.
	/// </summary>
	public class FileModel {
		#region Constructor
		/// <summary>
		/// Initialize a new instance of the FileModel class.
		/// </summary>
		/// <param name="FilePath">The file path.</param>
		public FileModel(string FilePath) {
			// Retrieve the successful match.
			Match Match = MatchModel.Expressions.Select(x => x.Match(Path.GetFileNameWithoutExtension(FilePath))).FirstOrDefault(x => x.Success);
			// Check if the match is valid.
			if (Match != null) {
				// Set the directory name.
				DirectoryName = Path.GetDirectoryName(FilePath);
				// Set the episode number.
				EpisodeNumber = Match.Groups["EpisodeNumber"].Value.Trim().AsNumeric();
				// Set the extension.
				Extension = Path.GetExtension(FilePath);
				// Set the file name.
				FileName = Path.GetFileName(FilePath);
				// Set the season number.
				SeasonNumber = string.IsNullOrWhiteSpace(Match.Groups["SeasonNumber"].Value) ? "01" : Match.Groups["SeasonNumber"].Value.Trim().AsNumeric();
				// Set the translation group.
				TranslationGroup = Match.Groups["TranslationGroup"].Value.Trim();
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Contains the directory name.
		/// </summary>
		public string DirectoryName { get; set; }

		/// <summary>
		/// Contains the episode number.
		/// </summary>
		public string EpisodeNumber { get; set; }

		/// <summary>
		/// Contains the extension.
		/// </summary>
		public string Extension { get; set; }

		/// <summary>
		/// Contains the file name.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Contains the season number.
		/// </summary>
		public string SeasonNumber { get; set; }

		/// <summary>
		/// Contains the translation group.
		/// </summary>
		public string TranslationGroup { get; set; }
		#endregion
	}
}