// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using System.Windows;
using System.Windows.Input;

namespace AnimeBatchRename.View {
	/// <summary>
	/// Represents the input view.
	/// </summary>
	public partial class InputView : Window {
		#region Abstract
		/// <summary>
		/// Occurs when pressed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event</param>
		private void _OnKeyDown(object sender, KeyEventArgs e) {
			// Check if this is the enter key.
			if (e.Key == Key.Enter) {
				// Set the result.
				Result = Input.Text;
				// Close the dialog.
				Close();
			}
		}

		/// <summary>
		/// Occurs when clicked.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event.</param>
		private void _OnOK(object sender, RoutedEventArgs e) {
			// Set the result.
			Result = Input.Text;
			// Close the dialog.
			Close();
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initialize a new instance of the InputView class.
		/// </summary>
		/// <param name="Title">The title.</param>
		public InputView(string Title) {
			// Initialize the component.
			InitializeComponent();
			// Focus the input.
			this.Input.Focus();
			// Set the title.
			this.Title = Title;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Contains the result.
		/// </summary>
		public string Result { get; private set; }
		#endregion

		#region Statics
		/// <summary>
		/// Show an input view as dialog.
		/// </summary>
		/// <param name="Owner">The owner.</param>
		/// <param name="Title">The title.</param>
		public static string ShowDialog(Window Owner, string Title) {
			// Initialize a new instance of the InputView class.
			InputView InputView = new InputView(Title);
			// Set the owner.
			InputView.Owner = Owner;
			// Show the dialog.
			InputView.ShowDialog();
			// Return the result.
			return InputView.Result;
		}
		#endregion
	}
}