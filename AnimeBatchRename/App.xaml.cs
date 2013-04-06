// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using AnimeBatchRename.Model;
using AnimeBatchRename.View;
using System;
using System.Windows;

namespace AnimeBatchRename {
	/// <summary>
	/// Represents the application.
	/// </summary>
	public partial class App : Application {
		/// <summary>
		/// Raises the Startup event.
		/// </summary>
		/// <param name="e">The event.</param>
		protected override void OnStartup(StartupEventArgs e) {
			// Check if an argument has been provided.
			if (e.Args.Length != 0) {
				// Initialize a new instance of the MainModel class.
				MainModel MainModel = new MainModel(e.Args[0].Trim());
				// Initialize a new instance of the MainView class.
				MainView MainView = new MainView();
				// Set the data context.
				MainView.DataContext = MainModel;
				// Show the window.
				MainView.Show();
			} else {
				// Terminate the process.
				Environment.Exit(0);
			}
		}
	}
}