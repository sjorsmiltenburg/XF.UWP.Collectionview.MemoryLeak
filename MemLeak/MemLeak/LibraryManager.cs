using System.Collections.Generic;

namespace MemLeak
{
    internal class LibraryManager
    {
        private static List<string> sourceUrls = new List<string>();

        //            "https://bbstorage.blob.core.windows.net/documents/d05db82b-ab06-4950-bdf9-b2275c35da79_w200.jpg",
        //            "https://bbstorage.blob.core.windows.net/documents/75dfc5c4-4ba4-4c4b-a2e4-6a8bdd9bf21a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/88be40ab-08d9-44ce-a3db-fb0f63ff0886_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/26befa24-caa2-4a8b-ba5d-0f5177d018c8_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f0832880-b242-483b-a71b-5053c0c1ef03_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/5b5ee5c9-7788-4fb2-adb1-198b2b899b06_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8603bed8-53bd-4c64-ba4d-7f613dd7c3b1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f6ed5d51-d44d-469a-bf82-cae86d1482a4_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/7742afcc-c903-4355-860e-580950633c6e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/36cc4e6c-964f-429e-af9b-f406159dc72c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/7c99a21e-0c78-433b-8168-c8695120ae29_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c0151e4e-5786-4b3e-8fcc-098af8d33a78_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/34f0afa4-f991-4753-9840-79e838d06e36_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/4034b9c7-2f63-4dce-9d18-a28a76c730c0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/13dd472f-cf7d-4e4d-95ed-8a5242d9ada9_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/099c1c01-3f3c-41f4-ad37-5c421fbcb0fa_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/7a0db412-cc86-4a7d-9f2c-9d68816551a4_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/42d4bef7-1af3-40ac-89dc-b699bf1b4a28_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/feae9079-7002-44fc-945e-c14d16440b2b_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/166a974e-4ac9-4acd-8416-96ed76325fea_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/fa5516ee-3a09-4531-9463-45b9382a5d3f_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f2b86b81-6954-4512-997a-c59092802bd1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/3a214810-9c66-4bed-9553-d9efc2888ada_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/293f7452-c089-45db-b6b0-c2fbc174619e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/2630e5ba-e0c8-42c8-820c-6c98febb09b0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/9eacbdd7-dc63-43e2-a4b6-aaa2a839e71c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/72d6278b-b86e-4f46-885c-6697827850dc_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8a1b730e-ca76-4184-b96c-a6cb161b99ac_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f1f23af7-7478-41cc-8be1-0b70980fd8ba_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/fc1f9c20-f74d-4257-8629-3f3934db7020_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/24a455db-6edf-439b-9541-3e14d20a0959_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/06364941-57f5-4189-a316-7396800bffac_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/9d2b891b-44dd-4470-ac49-a4bd7c4743ea_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d3650c7c-32cd-4110-b497-b06ff1ffea1f_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/49bdf524-c2d4-4ffa-9394-570c98a03a65_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/276562dd-c298-4d4f-92f8-c7e63bd0c95a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/22147eaa-a354-4799-91f1-b9726b82c44d_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/6abe157e-bf69-4ad6-bada-a5063ea01d0a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c6a9ef59-6f54-4358-bff2-dcf8bf49c3a3_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/a48a41de-6e79-4ef4-a9a2-b2e41800f56d_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/79901602-6acc-4a0f-bb74-a4e3a6f3ffaa_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/07d743bb-dd17-45a7-9a79-8d5913878cdc_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/90a827a7-bfdf-4947-b73f-1508834379e8_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/1c5495c5-f536-4a93-96cf-491f280c96d3_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e971e468-0c3a-40eb-b6a9-a501276bcd5e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/33e55180-e82a-483a-9e71-3f3dc73622a8_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c0b5c247-0339-489c-a8ae-2e040034c93c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/76c53df4-2138-4075-8b23-65b638d2f014_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/0c1d8f70-d4f5-4edb-aa94-c0ff7e9726c9_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/86691924-711b-4a51-b94e-5e035d25fe9a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/55833c77-71a8-417b-b760-eab97802ee02_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b604a9ab-8783-4046-866a-46f9963a82fa_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b7992dae-5aeb-4da8-966e-5d73ab20ec81_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d8fea711-54b2-493a-b954-010a77e60de6_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/dfdf2d51-df8f-4152-9048-86de8d8426e3_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b73dbc71-6329-4fdc-9d9b-29eadbbf47db_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/bd61a79d-9d60-4b9e-a313-a3056cc76c74_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/efd2e76e-6974-45bc-a81c-6e8b93ec4b5c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d72df384-29fe-492a-8640-e9bf8e679b9d_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/5ee7770c-1048-4360-8598-cbb1f83b6f39_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/21874267-8898-40c1-8c7c-5b11b6ba8c0c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/0054ff28-4eb8-49d3-85af-ea6afb9ccadc_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/ab39ba7a-344b-4af1-89d7-e4223cd748c3_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/510ae17c-42d2-4f1b-861e-62250ba6976a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/180974b7-6f61-43ce-a636-57792a69e58e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/1c925da9-1006-4a56-b1f4-56d2a58a3f4b_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f7ec7cbc-e996-4f1c-83c7-464ce3d27216_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/59337b91-7f88-4a69-92db-26c2287f8273_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f0131e59-66a0-477e-aab7-d14744560f57_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/847f686a-ed45-4c0f-8412-206da42a998f_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/5e0995b3-65aa-4047-8bf7-ea5cd5bc7617_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d952de33-1b64-4ef1-b8f7-50b3420e62aa_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/1e2ad129-f864-49a8-b98a-8f4c224aeee1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b2b86967-4a48-45fe-9b05-cbbba984c4cb_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/660b6f6f-6231-4a57-a8a2-2b23363a0e5e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/0ff5d745-0931-494d-b08d-43e4a5192407_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e34e1257-5184-410e-b523-8e0d9a51d9c4_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/ad6ef0aa-d1a1-4803-aca7-a193e75eb5e5_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/a74a2347-ad0a-4620-bc03-fae48eb8fa4e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/363901d6-581a-4cb2-beb7-0e34e8ab5fe1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c86263f9-1bcc-4c63-b9b3-e75a4fd52a02_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/360a39df-495a-4ed6-bdfb-6933181667e1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8298e7c7-2c4c-4e2a-9a19-c5c9616bab12_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e8e87918-87ea-4fb3-9cec-1c21bc9a7801_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e2338ae9-7755-4cbe-8ebc-8ae99a764b40_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/56dc7ba6-b352-4201-ac30-f17f5bb2a916_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/19fdeaae-133a-41ae-8991-816e7d933718_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/2bee289c-f966-43e6-bcd5-73aa24b284db_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b353afbb-d999-4270-a61b-15927d8f7ffc_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/9920c512-d224-4f41-b30c-c3fb5a0fbdc0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/686ab05f-99fd-46cf-a52c-636a989bbec3_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/af2e67be-fb3c-44a8-aac4-129e0f0ebdd6_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/6ac9686d-94ff-495b-b553-32cd2da681b8_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/866ffd6b-921a-4c86-98cf-f63c6171dac0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/1b3312d8-7684-425c-ad11-a4a9660e01f2_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/1d3c238c-e985-4edd-b568-40db0ff38d7c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f1ae8196-4dff-4ad7-a5a5-4262d85ec3bc_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/433b32bd-6d6f-4cf1-8dc0-060b1e879173_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/862e6b3a-2134-445c-9075-862abb47f375_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/35480ff9-e965-4ba4-9880-5f4fcdead5ab_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/dc73a5a5-c24d-467a-ac5d-4ead69e92b70_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/3034c19f-1f72-47e4-b420-7106d4f7da22_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/afd6c536-0fdb-4156-8fd7-096b4dd2c2ea_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/98d3c067-b0e7-4e5f-a9d5-bd9af5874f6e_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/dd5957ff-62b2-40f2-8448-1c28fbacbcf3_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/3bea99b3-6754-40a9-944b-6cfe22cffd9d_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/67e9dd0c-5952-4e6b-b9da-75e57927230a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/99ff55fe-1af3-49db-9153-7ea0421b2b46_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f792cd16-e2d7-45e2-ba55-7671b66736e0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/cfaf9492-6e47-4795-8068-3acea739c11c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d22fb6c2-1364-4f3e-84cb-b5b7acf7928f_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/edcd9a3e-72fc-44ff-a3c1-d8e8799f6ad9_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b6fc8eef-924a-47d7-b246-fbc8acd1b804_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/26fba5e5-25fb-47ca-a9ae-945cfae2c02b_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/4de8c18b-d24d-4f9b-b591-cd04bfb61fb4_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/ca59e932-ed15-438b-a186-89f13b46d43a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c52813ab-0cbb-4025-b940-80bba19e535b_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b94ae1d5-b207-4d78-a736-424906c28687_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/466aa8a2-17d0-43e3-b5f1-dbf5abb04c64_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c6dd8b51-c6a6-4201-a7f6-3664dce1369b_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/402ab2e1-aa3f-4a53-b6b8-1618819317df_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/729bd9f6-029b-4798-b338-39c0e140a222_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/a9e3eb6c-e38e-4ae7-a465-bd377fad41b9_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8c13601e-4737-4078-9273-38cc72952775_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/044c5a7b-ad30-4dae-bec0-39975553ee37_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/78d7bc4f-7d44-4de7-9bb6-dbc347fbff24_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e2ed51e0-bad4-494f-bbc6-61681edff570_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/0900c790-e416-48be-a9e9-877cf525ad80_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/965dd478-b612-424c-b297-924819efa1ef_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/54c1f2ed-4ec2-4851-8b81-83fc3feff2f1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/0e21af9e-d29b-4f9c-800c-35900180cc72_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e61ed2e7-5592-4ab7-ace5-23f882bdcb44_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/2b5ff5c6-604d-493d-9d8d-be529d61245c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f46082d2-4948-44ac-8768-316a5e804de0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/c0d18214-1574-4e3d-8b34-afd14e8254a8_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/75c968d5-56c3-49e9-909f-a3f5f7d44f84_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/3ed5b37a-1f31-49be-855e-8855100b4d0a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8a47d29c-fbf1-4577-a9ed-0c81097e8844_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/1750b077-770f-4ee6-b510-9c2a5abb22de_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/82dde4e1-1184-445c-b698-6aa988b20f07_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/f6e5716c-1f88-480f-a255-420e328aac7a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/0968c88b-1a98-48dd-97a1-98ddad8ee908_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/821f4c86-2d9f-474a-b714-f79c983ae0bf_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/24e3a83d-603b-458c-a993-44d4a6f602ad_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/e5cafe29-e815-40ae-9e80-6ac0822d668a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/cf3fddd0-843c-4ee1-9b21-c26cc754ed90_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8074f8dc-467b-4056-9da9-71dc2b916a52_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/8c87619f-d937-4e42-8ac1-e841e43deec6_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/6bc1e6ec-47d9-48c8-9f63-2cda29229df0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/7f8cacd0-6973-4953-b309-f1b7b42aa91b_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/30202dd0-c828-4729-aa01-45de7c56f854_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/422881a3-8bc2-44b1-850c-19bb18a0c468_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/ab7c2acb-e122-48f5-aa52-5072d4d1ab0c_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/9c2c2110-cf75-4a09-9933-e08cc807429f_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/9611cd6d-0948-447f-94e1-b38497c16fc1_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/b2f0cfed-d13e-4952-8879-328c08c75ca0_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/4adc2c19-4ee8-401d-8dbe-94728ed37e6a_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/91fd378e-133c-4a08-8d02-5f7682f286c7_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/a960196c-3d8d-43be-8609-fd9e2b88d446_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d7e6291c-1614-4e92-bd62-630e23e09229_w200.jpg",
        //"https://bbstorage.blob.core.windows.net/documents/d3b5bfe7-397a-4927-957a-441acc5cdeb5_w200.jpg" 



        private static LibraryManager _instance;
        public static LibraryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LibraryManager();
                }
                return _instance;
            }
        }

        public LibraryManager()
        {
            for (int i = 0; i < 150; i++)
            {
                sourceUrls.Add($@"https://loremflickr.com/200/271/lock=" + i);
            }

            foreach (var sourceUrl in sourceUrls)
            {
                LibraryPublicationViewModel viewModel = new LibraryPublicationViewModel();
                viewModel.Init(sourceUrl);
                AllPublicationViewModels.Add(viewModel);
            }

        }

        public List<LibraryPublicationViewModel> AllPublicationViewModels { get; private set; } = new List<LibraryPublicationViewModel>();
    }
}