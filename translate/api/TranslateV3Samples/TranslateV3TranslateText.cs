// Copyright 2019 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START translate_v3_translate_text]
using Google.Cloud.Translate.V3;
using System;
using System.Collections.Generic;

namespace GoogleCloudSamples
{
    public static class TranslateV3TranslateText
    {
        /// <summary>
        /// Translating Text
        /// </summary>
        /// <param name="text">The content to translate in string format</param>
        /// <param name="targetLanguage">Required. The BCP-47 language code to use for translation.</param>
        public static void TranslateTextSample(string text, string targetLanguage, string projectId)
        {
            TranslationServiceClient translationServiceClient = TranslationServiceClient.Create();
            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents =
                {
                    // The content to translate in string format
                    text,
                },
                TargetLanguageCode = targetLanguage,
                ParentAsLocationName = new LocationName(projectId, "global"),
            };
            TranslateTextResponse response = translationServiceClient.TranslateText(request);
            // Display the translation for each input text provided
            foreach (Translation translation in response.Translations)
            {
                Console.WriteLine($"Translated text: {translation.TranslatedText}");
            }
        }
    }

    // [END translate_v3_translate_text]
}
