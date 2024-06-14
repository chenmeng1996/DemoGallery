function CompareDate {
    $Start = Get-Date -Year 2021 -Month 1 -Day 1
    $End = Get-Date -Year 2022 -Month 7 -Day 27

    $Target1 = Get-Date -Year 2022 -Month 6 -Day 28
    $Target2 = Get-Date -Year 2022 -Month 7 -Day 28

    if ($Target1 -ge $Start -and $Target1 -le $End) {
        Write-Output $true
    } else {
        Write-Output $false
    }
    if ($Target2 -ge $Start -and $Target2 -le $End) {
        Write-Output $true
    } else {
        Write-Output $false
    }
}

function LastDayOfMonth {
    $DateWithMonth = Get-Date -Year 2022 -Month 6
    $lastDay = [DateTime]::DaysInMonth($DateWithMonth.Year, $DateWithMonth.Month)
    $LastDate  = [DateTime]::new($Date.Year, $Date.Month, $lastDay)
}

function ParseDateToString {
    $DateWithMonth = Get-Date -Year 2022 -Month 6 -Day 1
    $dateString = $lastDate.ToString("yyyy-MM-dd")
    $dateYear = $lastDate.Year
    $dateMonth = $lastDate.Month.ToString("D2")
    $dateDay = $lastDate.Day.ToString("D2")
}


CompareDate