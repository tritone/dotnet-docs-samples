/*
 * Copyright 2020 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// [START kms_create_key_symmetric_encrypt_decrypt]

using Google.Cloud.Kms.V1;

public class CreateKeySymmetricEncryptDecryptSample
{
    public CryptoKey CreateKeySymmetricEncryptDecrypt(
      string projectId = "my-project", string locationId = "us-east1", string keyRingId = "my-key-ring",
      string id = "my-symmetric-encryption-key")
    {
        // Create the client.
        KeyManagementServiceClient client = KeyManagementServiceClient.Create();

        // Build the parent key ring name.
        KeyRingName keyRingName = new KeyRingName(projectId, locationId, keyRingId);

        // Build the key.
        CryptoKey key = new CryptoKey
        {
            Purpose = CryptoKey.Types.CryptoKeyPurpose.EncryptDecrypt,
            VersionTemplate = new CryptoKeyVersionTemplate
            {
                Algorithm = CryptoKeyVersion.Types.CryptoKeyVersionAlgorithm.GoogleSymmetricEncryption,
            }
        };

        // Call the API.
        CryptoKey result = client.CreateCryptoKey(keyRingName, id, key);

        // Return the result.
        return result;
    }
}
// [END kms_create_key_symmetric_encrypt_decrypt]
