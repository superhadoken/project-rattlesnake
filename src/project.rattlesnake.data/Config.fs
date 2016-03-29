namespace project.rattlesnake.data
open System.Configuration

module GetMyConfig =
      let config  = 
        #if COMPILED 
          ConfigurationManager.GetSection("MyConfig") :?> Config
        #else                        
          let path = __SOURCE_DIRECTORY__ + "/app.config"
          let fileMap = ConfigurationFileMap(path) 
          let config = ConfigurationManager.OpenMappedMachineConfiguration(fileMap) 
          config.GetSection("MyConfig") :?> MyConfig
        #endif
