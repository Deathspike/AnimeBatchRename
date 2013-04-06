// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================

namespace AnimeBatchRename.Extension {
	/// <summary>
	/// Represents the class providing extensions for the String class.
	/// </summary>
	public static class ExtensionForString {
		/// <summary>
		/// Convert the value to use a numeric notation.
		/// </summary>
		/// <param name="Value">The value.</param>
		public static string AsNumeric(this string Value) {
			// Initialize the current.
			double Current;
			// Return the (modified) value.
			return double.TryParse(Value, out Current) ? Current.ToString("00.####") : Value;
		}
	}
}