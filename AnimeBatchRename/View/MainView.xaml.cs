// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using AnimeBatchRename.Model;
using System.Windows;

namespace AnimeBatchRename.View {
	/// <summary>
	/// Represents the main view.
	/// </summary>
	public partial class MainView : Window {
		#region Abstract
		/// <summary>
		/// Occurs when clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event.</param>
		private void _OnChangeEpisode(object sender, RoutedEventArgs e) {
			// Initialize the input.
			string Input = InputView.ShowDialog(this, "Episode Mutation");
			// Initialize the value.
			int Current, Value;
			// Parse the input to value and check for success.
			if (int.TryParse(Input, out Value)) {
				// Iterate through each selected item.
				foreach (object Item in DataGrid.SelectedItems) {
					// Initialize the file model.
					FileModel FileModel = (FileModel) Item;
					// Parse the episode number to current and check for success.
					if (int.TryParse(FileModel.EpisodeNumber, out Current)) {
						// Set the episode number.
						FileModel.EpisodeNumber = (Current + Value).ToString("00.####");
					}
				}
				// Refresh the items.
				DataGrid.Items.Refresh();
				// Focus the data grid.
				DataGrid.Focus();
			}
		}

		/// <summary>
		/// Occurs when clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event.</param>
		private void _OnChangeSeason(object sender, RoutedEventArgs e) {
			// Initialize the input.
			string Input = InputView.ShowDialog(this, "Season");
			// Initialize the value.
			int Value;
			// Parse the input to value and check for success.
			if (int.TryParse(Input, out Value)) {
				// Iterate through each selected item.
				foreach (object Item in DataGrid.SelectedItems) {
					// Initialize the file model.
					FileModel FileModel = (FileModel) Item;
					// Set the episode number.
					FileModel.SeasonNumber = Value.ToString("00");
				}
				// Refresh the items.
				DataGrid.Items.Refresh();
				// Focus the data grid.
				DataGrid.Focus();
			}
		}

		/// <summary>
		/// Occurs when clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event.</param>
		private void _OnChangeTranslationGroup(object sender, RoutedEventArgs e) {
			// Initialize the input.
			string Input = InputView.ShowDialog(this, "Translation Group");
			// Iterate through each selected item.
			foreach (object Item in DataGrid.SelectedItems) {
				// Initialize the file model.
				FileModel FileModel = (FileModel) Item;
				// Set the translation group.
				FileModel.TranslationGroup = Input;
			}
			// Refresh the items.
			DataGrid.Items.Refresh();
			// Focus the data grid.
			DataGrid.Focus();
		}

		/// <summary>
		/// Occurs when clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event.</param>
		private void _OnCommit(object sender, RoutedEventArgs e) {
			// Commit the changes.
			((MainModel) DataContext).Commit();
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initialize a new instance of the MainView class.
		/// </summary>
		public MainView() {
			// Initialize the component.
			InitializeComponent();
		}
		#endregion
	}
}