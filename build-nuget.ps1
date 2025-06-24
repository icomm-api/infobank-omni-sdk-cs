# NuGet Package Build Script for Infobank Omni SDK
# This script builds the project and creates a NuGet package

Write-Host "Building Infobank Omni SDK NuGet Package..." -ForegroundColor Green

# Clean previous builds
Write-Host "Cleaning previous builds..." -ForegroundColor Yellow
dotnet clean

# Restore packages
Write-Host "Restoring packages..." -ForegroundColor Yellow
dotnet restore

# Build the project
Write-Host "Building project..." -ForegroundColor Yellow
dotnet build --configuration Release

# Create NuGet package
Write-Host "Creating NuGet package..." -ForegroundColor Yellow
dotnet pack --configuration Release --output ./nupkg

Write-Host "NuGet package created successfully!" -ForegroundColor Green
Write-Host "Package location: ./nupkg/" -ForegroundColor Cyan

# List created packages
Write-Host "`nCreated packages:" -ForegroundColor Cyan
Get-ChildItem ./nupkg/*.nupkg | ForEach-Object {
    Write-Host "  - $($_.Name)" -ForegroundColor White
}
