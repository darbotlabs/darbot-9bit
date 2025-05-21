# PowerShell script to automate deploying games

param (
    [string]$projectPath = ".",
    [string]$outputPath = "./bin",
    [string]$deployPath = "./deploy"
)

function Deploy-Game {
    param (
        [string]$projectPath,
        [string]$outputPath,
        [string]$deployPath
    )

    Write-Host "Deploying game project from $outputPath to $deployPath..."

    # Ensure the deploy directory exists
    if (-Not (Test-Path $deployPath)) {
        New-Item -ItemType Directory -Path $deployPath
    }

    # Copy the built game files to the deploy directory
    Copy-Item -Path "$outputPath\*" -Destination $deployPath -Recurse -Force

    Write-Host "Game project deployed successfully to $deployPath"
}

Deploy-Game -projectPath $projectPath -outputPath $outputPath -deployPath $deployPath
