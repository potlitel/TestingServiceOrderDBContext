namespace WebApiSO.Data.Seeders.Helpers
{
    internal static class SampleData
    {
        public static readonly List<string> Descriptions;
        public static readonly List<string> Observations;
        public static readonly List<string> Address;

        static SampleData()
        {
            Descriptions = new List<string> {
                    "Orden de Trabajo",
                    "Solicitud de Servicio",
                    "Checklist de mantenimiento",
                    "Manual de uso y mantenimiento",
                    "Programa de mantenimiento preventivo",
                    "Procedimientos operativos estándar",
                    "Informes y Reportes",
                    "Especificaciones Técnicas",
                };

            Observations = new List<string> {
                    "Revisión y mantenimiento de transformadores en Salvador.",
                    "Reparación de líneas de transmisión en Feira de Santana.",
                    "Sustitución de postes dañados en Vitória da Conquista.",
                    "Limpieza y mantenimiento de subestaciones en Ilhéus.",
                    "Inspección de redes aéreas en Juazeiro.",
                    "Reparación de fallas en el sistema de distribución en Camaçari.",
                    "Mantenimiento preventivo de redes subterráneas en Lauro de Freitas.",
                    "Reemplazo de cables deteriorados en Itabuna.",
                    "Verificación de medidores de energía en Jequié.",
                    "Reparación de cortocircuitos en Alagoinhas.",
                    "Mantenimiento de sistemas de protección en Barreiras.",
                    "Revisión de conexiones domiciliarias en Teixeira de Freitas.",
                    "Reparación de daños por tormentas en Porto Seguro.",
                    "Sustitución de fusibles en Eunápolis.",
                    "Inspección de redes en áreas rurales de Santo Antônio de Jesus.",
                    "Mantenimiento de equipos de medición en Simões Filho.",
                    "Reparación de líneas de alta tensión en Paulo Afonso.",
                    "Revisión de sistemas de iluminación pública en Jacobina.",
                    "Mantenimiento de subestaciones en Valença.",
                    "Reparación de cables submarinos en Mata de São João.",
                    "Inspección de redes en áreas comerciales de Senhor do Bonfim.",
                    "Mantenimiento de sistemas de control en Cruz das Almas.",
                    "Reparación de fallas en el suministro eléctrico en Guanambi.",
                    "Revisión de equipos de generación en Serrinha.",
                    "Mantenimiento de redes en áreas industriales de Candeias.",
                    "Reparación de daños por inundaciones en Itamaraju.",
                    "Inspección de líneas de transmisión en Conceição do Coité.",
                    "Mantenimiento de sistemas de distribución en Amargosa.",
                    "Reparación de cortes de energía en Santa Maria da Vitória.",
                    "Revisión de sistemas de seguridad en Irecê.",
                };

            Address = new List<string>
                {
                    "Avenida Mar Azul, 456 – Salvador, BA – CEP: 401 BA – CEP: 40000-001",
                    "Travessa das Palmeiras, ente, 456 – Feira de Santana, BA – CEP: 44000-002",
                    "Travessa do789 – Feira de Santana, BA – CEP: 44001-230",
                    "Rua dos Coqueiros, 101 – Camaçari,101** – Vitória da Conquista, BA – CEP: 45020- BA – CEP: 42800-004",
                    "Alameda das Ondas, 202 – Ilhéus, BAabuna, BA – CEP: 45600-005",
                    "Alameda do Horizonte, 404** – Ilhéus, BA – CEP: 45650-0077. Avenida Beira-Mar, 404 – Itacaré",
                    "Rua do Farol, 505 – Porto Seguro, BA – CEP: 45800 BA – CEP: 45530-600",
                    "Rua das Dunas, 707 – JequiTravessa do Pôr do Sol, 606é, BA – CEP: 45200-010",
                    "Lauro de Freitas, BA – CEP: 42700-Estrada do Sol, 808** – Barreiras, BA – CEP: 47800800",
                    "Avenida do Farol – Alagoinhas, BA – CEP: 48000, 808 – Juazeiro, BA – CEP: 48900-012",
                    "Rua do Cacau, 909 – Il Teixeira de Freitas, BA – CEP: 45900-013",
                    "Praça das Águas14. Rua das Araras, 222 – Simões Filho, BA – CEP: 43700 Claras, 111 – Alagoinhas, BA – CEP: 48000-300",
                    "Praça do Pôr do Sol, 333 – Paulo Afonso, Rua do Mar Sereno, 222 – Itab BA – CEP: 48600-015",
                    "Eunápolis, BA – CEP: 45820-. Estrada das Dunas, 333 – Valença, BA – CEP:016",
                    "Rua das Ar Valença, BA – CEP: aras, 444 – Jequié45400-017",
                    "Alameda das Gaivotas Santo Antônio de Jesus, BA – CEP: 44500-018",
                    "Simões Filho,Travessa do L BA – CEP: 43700-700",
                    "Avenida das Estrelas, 777 – Santo – Senhor do Bonfim, BA – CEP: 48970-020",
                    "Guanambi, BA – CEP: 46400Rua da Brisa Suave, 666** – Paulo Afonso, BA – CEP-019",
                    "Avenida das Palmeiras Antônio de Jesus, BA – CEP: 44500-900",
                    "Travessa do Horizonte, 999 – Jacobina, BA – CEP: 44700-, 888** – Eunápolis, BA – CEP: 021",
                    "Rua dos Ventos do Norte, 999 Irecê, BA – CEP: 44900-022",
                    "Alameda – Teixeira de Freitas, BA – CEP: 45985-200",
                    "Avenida Lago Azul, 1234 – Serrinha 43800-023",
                    "Avenida Costa Azul, 343 – Itapetinga, BA – CEP: 48700-300",
                    "Travessa dos Pescadores, 565 – Ipirá, BA – CEP: 44600 – Jacobina, BA – CEP: 44700-500",
                    "Rua do Rio Doce, Serena, 1122 – Cruz das Al 676** – Brumado, BA – CEP: 46100-027",
                    "Rua doRua das Andorinhas, 898 – Serrinha, BA – CEP: 48700",
                    "Estrada das Mangueiras, 909 Guanambi, BA – CEP: 46430-800",
                    "Estrada do – Conceição do Coité, BA – CEP: 48730- Sol Radiante, 7788 – Bom Jesus da Lapa030",
                };
        }
    }
}
