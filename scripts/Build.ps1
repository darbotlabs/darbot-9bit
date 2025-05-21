# PowerShell script to automate building games

param (
    [string]$projectPath = ".",
    [string]$outputPath = "./bin"
)

function Build-Game {
    param (
        [string]$projectPath,
        [string]$outputPath
    )

    Write-Host "Building game project at $projectPath..."

    # Restore project dependencies
    dotnet restore $projectPath

    # Build the project
    dotnet build $projectPath -o $outputPath

    Write-Host "Game project built successfully. Output located at $outputPath"
}

Build-Game -projectPath $projectPath -outputPath $outputPath
