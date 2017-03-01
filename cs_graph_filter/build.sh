#!/bin/sh


OUT_DIR="./"
OUT_FILE="FiltersTest.exe"



FILTER_LIB="Filters/*.cs"
FILTER_LIB_TESTS="Filters/UnitTests/*.cs"

TEST_LIB="TestInterface/*.cs"

FORM_LIB="GraphForm/*.cs"


#mcs -pkg:dotnet ${FILTER_LIB} ${FILTER_LIB_TESTS} ${TEST_LIB} ${FORM_LIB}  -out:"${OUT_DIR}${OUT_FILE}"
mcs -pkg:dotnet ${FORM_LIB}  -out:"${OUT_DIR}${OUT_FILE}"

