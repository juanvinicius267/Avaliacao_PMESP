using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Avaliação_PMESP.SqlServer
{
    public class SqlServerUpdate
    {
        public static void ExecuteScriptSql(string connectionString)
        {
            var upgrader =
                DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("Erro ao executar os scripts .sql");
            }
        }
    }
}
