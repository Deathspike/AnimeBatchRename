// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AnimeBatchRename.Model {
	/// <summary>
	/// Represents the match model.
	/// </summary>
	public static class MatchModel {
		/// <summary>
		/// Contains each expression.
		/// </summary>
		public static IEnumerable<Regex> Expressions {
			get {
				// Return each expression.
				return new List<Regex> {
					// [NanohaFan] Mahou Shoujo Lyrical Nanoha (1x)04 - A Rival!? Another Magical Girl!
					new Regex(@"^(\[(?<TranslationGroup>.+?)\])(.*?)(_|\s)((?<SeasonNumber>[0-9]+)x)?(?<EpisodeNumber>[0-9]+(\.|,)?([0-9]+)?)"),
					// Mahou Shoujo Lyrical Nanoha (1x)04 - A Rival!? Another Magical Girl! [NanohaFan]
					new Regex(@"(_|\s)((?<SeasonNumber>[0-9]+)x)?(?<EpisodeNumber>[0-9]+(\.|,)?[0-9]+?)(.*)(\[(?<TranslationGroup>[^\[]+?)\])$"),
					// Mahou Shoujo Lyrical Nanoha (1x)04 - A Rival!? Another Magical Girl!
					new Regex(@"(_|\s)((?<SeasonNumber>[0-9]+)x)?(?<EpisodeNumber>[0-9]+(\.|,)?[0-9]+?)(.*)?$")
				};
			}
		}
	}
}