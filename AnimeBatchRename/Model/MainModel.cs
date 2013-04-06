// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnimeBatchRename.Model {
	/// <summary>
	/// Represents the main model.
	/// </summary>
	public sealed class MainModel {
		#region Constructor
		/// <summary>
		/// Initialize a new instance of the MainModel class.
		/// </summary>
		/// <param name="DirectoryPath">The directory path.</param>
		public MainModel(string DirectoryPath) {
			// Initialize a new instance of the List class.
			Files = new List<FileModel>();
			// Set the title.
			Title = Path.GetFileName(DirectoryPath);
			// Iterate through each file in the directory.
			foreach (string FilePath in Directory.GetFiles(DirectoryPath).OrderBy(x => x)) {
				// Retrieve the extension.
				string Extension = Path.GetExtension(FilePath);
				// Check if the extension is allowed.
				if (Regex.Match(Extension, @"^\.(avi|ass|idx|ogm|mkv|mp4|srt|sub)$").Success) {
					// Initialize a new instance of the FileModel class.
					FileModel FileModel = new FileModel(FilePath);
					// Check if the episode number is valid.
					if (!string.IsNullOrWhiteSpace(FileModel.EpisodeNumber)) {
						// Add the file.
						Files.Add(FileModel);
					}
				}
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Commit the changes.
		/// </summary>
		public void Commit() {
			// Iterate through each file.
			foreach (FileModel FileModel in Files) {
				// Initialize the old name.
				string OldName = Path.Combine(FileModel.DirectoryName, FileModel.FileName);
				// Initialize the new name.
				string NewName = Path.Combine(FileModel.DirectoryName, string.Format("{0} {1}x{2}{3}{4}", Title, FileModel.SeasonNumber, FileModel.EpisodeNumber, string.IsNullOrWhiteSpace(FileModel.TranslationGroup) ? string.Empty : string.Format(" [{0}]", FileModel.TranslationGroup), FileModel.Extension));
				// Rename the file.
				File.Move(OldName, NewName);
			}
			// Terminate the process.
			Environment.Exit(0);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Contains each file.
		/// </summary>
		public List<FileModel> Files { get; set; }

		/// <summary>
		/// Contains the title.
		/// </summary>
		public string Title { get; set; }
		#endregion
	}
}