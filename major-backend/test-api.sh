#!/bin/bash
# ============================================================
#  Hartford Insurance API — Full Endpoint Test Suite
#  Backend: http://localhost:5254
# ============================================================

BASE="http://localhost:5254"
PASS=0
FAIL=0

# Colors
GREEN='\033[0;32m'; RED='\033[0;31m'; YELLOW='\033[1;33m'; CYAN='\033[0;36m'; NC='\033[0m'

check() {
  local label="$1" expected="$2" actual="$3"
  if echo "$actual" | grep -q "$expected"; then
    echo -e "  ${GREEN}✅ PASS${NC} — $label"
    ((PASS++))
  else
    echo -e "  ${RED}❌ FAIL${NC} — $label"
    echo -e "     Expected to contain: ${YELLOW}$expected${NC}"
    echo -e "     Got: ${RED}$(echo "$actual" | head -c 200)${NC}"
    ((FAIL++))
  fi
}

echo -e "\n${CYAN}════════════════════════════════════════════════════════"
echo -e "  Hartford Insurance API — Test Suite"
echo -e "════════════════════════════════════════════════════════${NC}\n"

# ── 1. AUTH ────────────────────────────────────────────────────────────────────
echo -e "${CYAN}[1] AUTH${NC}"

# Login as admin
ADMIN_RESP=$(curl -s --max-time 10 "$BASE/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"Email":"admin@insurance.com","Password":"admin123"}')
check "POST /api/auth/login (admin)" '"Role":"admin"' "$ADMIN_RESP"
ADMIN_TOKEN=$(echo "$ADMIN_RESP" | python3 -c "import sys,json; print(json.load(sys.stdin).get('Token',''))" 2>/dev/null)

# Login as agent
AGENT_RESP=$(curl -s --max-time 10 "$BASE/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"Email":"agent@insurance.com","Password":"password123"}')
check "POST /api/auth/login (agent)" '"Role":"agent"' "$AGENT_RESP"

# Login as customer
CUST_RESP=$(curl -s --max-time 10 "$BASE/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"Email":"customer@insurance.com","Password":"password123"}')
check "POST /api/auth/login (customer)" '"Role":"customer"' "$CUST_RESP"
CUST_TOKEN=$(echo "$CUST_RESP" | python3 -c "import sys,json; print(json.load(sys.stdin).get('Token',''))" 2>/dev/null)

# Wrong password
BAD_RESP=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 "$BASE/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"Email":"admin@insurance.com","Password":"wrongpass"}')
check "POST /api/auth/login (wrong password → 401)" "401" "$BAD_RESP"

# Register new user — use timestamp for a unique email each run
UNIQUE_EMAIL="testuser_$(date +%s)@insurance.com"
REG_RESP=$(curl -s --max-time 10 "$BASE/api/auth/register" \
  -H "Content-Type: application/json" \
  -d "{\"Name\":\"Test User\",\"Email\":\"$UNIQUE_EMAIL\",\"Password\":\"Test@123\",\"Role\":\"customer\"}")
check "POST /api/auth/register (new user)" '"Token"' "$REG_RESP"

# Duplicate register (same email)
DUP_RESP=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 "$BASE/api/auth/register" \
  -H "Content-Type: application/json" \
  -d "{\"Name\":\"Test User\",\"Email\":\"$UNIQUE_EMAIL\",\"Password\":\"Test@123\",\"Role\":\"customer\"}")
check "POST /api/auth/register (duplicate → 409)" "409" "$DUP_RESP"

echo ""
AUTH="Authorization: Bearer $ADMIN_TOKEN"

# ── 2. USERS ───────────────────────────────────────────────────────────────────
echo -e "${CYAN}[2] USERS${NC}"

USERS=$(curl -s --max-time 10 "$BASE/api/users" -H "$AUTH")
check "GET /api/users" '"Email"' "$USERS"

USER1=$(curl -s --max-time 10 "$BASE/api/users/1" -H "$AUTH")
check "GET /api/users/1" '"Id":1' "$USER1"

USEREMAIL=$(curl -s --max-time 10 "$BASE/api/users/by-email?email=admin@insurance.com" -H "$AUTH")
check "GET /api/users/by-email?email=admin@insurance.com" '"Role":"admin"' "$USEREMAIL"

NOUSER=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 "$BASE/api/users/9999" -H "$AUTH")
check "GET /api/users/9999 (not found → 404)" "404" "$NOUSER"

echo ""

# ── 3. CUSTOMERS ───────────────────────────────────────────────────────────────
echo -e "${CYAN}[3] CUSTOMERS${NC}"

CUSTOMERS=$(curl -s --max-time 10 "$BASE/api/customers" -H "$AUTH")
check "GET /api/customers" '"Name"' "$CUSTOMERS"

CUST1=$(curl -s --max-time 10 "$BASE/api/customers/1" -H "$AUTH")
check "GET /api/customers/1" '"Id":1' "$CUST1"

NEW_CUST=$(curl -s --max-time 10 "$BASE/api/customers" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"Name":"New Customer","Email":"newcust@test.com","Phone":"555-9999","Address":"456 Oak Ave"}')
check "POST /api/customers" '"Id"' "$NEW_CUST"

echo ""

# ── 4. AGENTS ──────────────────────────────────────────────────────────────────
echo -e "${CYAN}[4] AGENTS${NC}"

AGENTS=$(curl -s --max-time 10 "$BASE/api/agents" -H "$AUTH")
check "GET /api/agents" '"Name"' "$AGENTS"

AGENT1=$(curl -s --max-time 10 "$BASE/api/agents/1" -H "$AUTH")
check "GET /api/agents/1" '"Id":1' "$AGENT1"

echo ""

# ── 5. POLICIES ────────────────────────────────────────────────────────────────
echo -e "${CYAN}[5] POLICIES${NC}"

POLICIES=$(curl -s --max-time 10 "$BASE/api/policies" -H "$AUTH")
check "GET /api/policies" '"PolicyName"' "$POLICIES"

POL1=$(curl -s --max-time 10 "$BASE/api/policies/1" -H "$AUTH")
check "GET /api/policies/1" '"Id":1' "$POL1"

POL_BY_CUST=$(curl -s --max-time 10 "$BASE/api/policies?customerId=1" -H "$AUTH")
check "GET /api/policies?customerId=1" '"CustomerId":1' "$POL_BY_CUST"

NEW_POL=$(curl -s --max-time 10 "$BASE/api/policies" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"CustomerId":1,"AgentId":1,"PolicyName":"Term Life Insurance","Premium":999.99,"StartDate":"2026-02-22T00:00:00","EndDate":"2027-02-22T00:00:00","Status":"Active"}')
check "POST /api/policies" '"PolicyName":"Term Life Insurance"' "$NEW_POL"
NEW_POL_ID=$(echo "$NEW_POL" | python3 -c "import sys,json; print(json.load(sys.stdin).get('Id',0))" 2>/dev/null)

PATCH_POL=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 \
  -X PATCH "$BASE/api/policies/$NEW_POL_ID" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d "{\"CustomerId\":1,\"AgentId\":1,\"PolicyName\":\"Term Life Insurance Updated\",\"Premium\":1099.99,\"StartDate\":\"2026-02-22T00:00:00\",\"EndDate\":\"2027-02-22T00:00:00\",\"Status\":\"Active\"}")
check "PATCH /api/policies/$NEW_POL_ID → 204" "204" "$PATCH_POL"

DEL_POL=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 \
  -X DELETE "$BASE/api/policies/$NEW_POL_ID" -H "$AUTH")
check "DELETE /api/policies/$NEW_POL_ID → 204" "204" "$DEL_POL"

echo ""

# ── 6. CLAIMS ──────────────────────────────────────────────────────────────────
echo -e "${CYAN}[6] CLAIMS${NC}"

CLAIMS=$(curl -s --max-time 10 "$BASE/api/claims" -H "$AUTH")
check "GET /api/claims" "\[" "$CLAIMS"

NEW_CLAIM=$(curl -s --max-time 10 "$BASE/api/claims" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"CustomerId":1,"PolicyId":1,"Description":"Car accident damage","Amount":5000.00,"Status":"Pending"}')
check "POST /api/claims" '"Description":"Car accident damage"' "$NEW_CLAIM"
NEW_CLAIM_ID=$(echo "$NEW_CLAIM" | python3 -c "import sys,json; print(json.load(sys.stdin).get('Id',0))" 2>/dev/null)

CLAIMS_BY_CUST=$(curl -s --max-time 10 "$BASE/api/claims?customerId=1" -H "$AUTH")
check "GET /api/claims?customerId=1" '"CustomerId":1' "$CLAIMS_BY_CUST"

PATCH_CLAIM=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 \
  -X PATCH "$BASE/api/claims/$NEW_CLAIM_ID" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"CustomerId":1,"PolicyId":1,"Description":"Car accident damage","Amount":5000.00,"Status":"Approved"}')
check "PATCH /api/claims/$NEW_CLAIM_ID (approve) → 204" "204" "$PATCH_CLAIM"

echo ""

# ── 7. INSURANCE REQUESTS ──────────────────────────────────────────────────────
echo -e "${CYAN}[7] INSURANCE REQUESTS${NC}"

REQUESTS=$(curl -s --max-time 10 "$BASE/api/insuranceRequests" -H "$AUTH")
check "GET /api/insuranceRequests" '"Type"' "$REQUESTS"

REQ1=$(curl -s --max-time 10 "$BASE/api/insuranceRequests/1" -H "$AUTH")
check "GET /api/insuranceRequests/1" '"Id":1' "$REQ1"

NEW_REQ=$(curl -s --max-time 10 "$BASE/api/insuranceRequests" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"CustomerId":1,"AgentId":1,"Type":"Health","Amount":200000.00,"Status":"Pending"}')
check "POST /api/insuranceRequests" '"Type":"Health"' "$NEW_REQ"

REQ_BY_AGENT=$(curl -s --max-time 10 "$BASE/api/insuranceRequests?agentId=1" -H "$AUTH")
check "GET /api/insuranceRequests?agentId=1" '"AgentId":1' "$REQ_BY_AGENT"

echo ""

# ── 8. POLICY RECOMMENDATIONS ──────────────────────────────────────────────────
echo -e "${CYAN}[8] POLICY RECOMMENDATIONS${NC}"

RECS=$(curl -s --max-time 10 "$BASE/api/policyRecommendations" -H "$AUTH")
check "GET /api/policyRecommendations" '"PolicyName"' "$RECS"

REC1=$(curl -s --max-time 10 "$BASE/api/policyRecommendations/1" -H "$AUTH")
check "GET /api/policyRecommendations/1" '"Id":1' "$REC1"

NEW_REC=$(curl -s --max-time 10 "$BASE/api/policyRecommendations" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"RequestId":1,"PolicyName":"Silver Health Plan","Premium":450.00,"Coverage":"Up to 2,00,000"}')
check "POST /api/policyRecommendations" '"PolicyName":"Silver Health Plan"' "$NEW_REC"

RECS_BY_REQ=$(curl -s --max-time 10 "$BASE/api/policyRecommendations?requestId=1" -H "$AUTH")
check "GET /api/policyRecommendations?requestId=1" '"RequestId":1' "$RECS_BY_REQ"

echo ""

# ── 9. POLICY APPLICATIONS ─────────────────────────────────────────────────────
echo -e "${CYAN}[9] POLICY APPLICATIONS${NC}"

APPS=$(curl -s --max-time 10 "$BASE/api/policyApplications" -H "$AUTH")
check "GET /api/policyApplications" '"PolicyName"' "$APPS"

APP1=$(curl -s --max-time 10 "$BASE/api/policyApplications/1" -H "$AUTH")
check "GET /api/policyApplications/1" '"Id":1' "$APP1"

NEW_APP=$(curl -s --max-time 10 "$BASE/api/policyApplications" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"AgentId":1,"CustomerId":1,"PolicyName":"Critical Illness Cover","Status":"Pending"}')
check "POST /api/policyApplications" '"PolicyName":"Critical Illness Cover"' "$NEW_APP"

APPS_BY_AGENT=$(curl -s --max-time 10 "$BASE/api/policyApplications?agentId=1" -H "$AUTH")
check "GET /api/policyApplications?agentId=1" '"AgentId":1' "$APPS_BY_AGENT"

echo ""

# ── 10. NOTIFICATIONS ──────────────────────────────────────────────────────────
echo -e "${CYAN}[10] NOTIFICATIONS${NC}"

NOTIFS=$(curl -s --max-time 10 "$BASE/api/notifications" -H "$AUTH")
check "GET /api/notifications" '"Message"' "$NOTIFS"

NOTIFS_USER=$(curl -s --max-time 10 "$BASE/api/notifications?userId=1" -H "$AUTH")
check "GET /api/notifications?userId=1" '"UserId":1' "$NOTIFS_USER"

NEW_NOTIF=$(curl -s --max-time 10 "$BASE/api/notifications" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"UserId":1,"Message":"Your claim has been approved!","IsRead":false}')
check "POST /api/notifications" '"Message":"Your claim has been approved!"' "$NEW_NOTIF"
NEW_NOTIF_ID=$(echo "$NEW_NOTIF" | python3 -c "import sys,json; print(json.load(sys.stdin).get('Id',0))" 2>/dev/null)

PATCH_NOTIF=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 \
  -X PATCH "$BASE/api/notifications/$NEW_NOTIF_ID" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"UserId":1,"Message":"Your claim has been approved!","IsRead":true}')
check "PATCH /api/notifications/$NEW_NOTIF_ID (mark read) → 204" "204" "$PATCH_NOTIF"

echo ""

# ── 11. PAYMENTS ───────────────────────────────────────────────────────────────
echo -e "${CYAN}[11] PAYMENTS${NC}"

PAYMENTS=$(curl -s --max-time 10 "$BASE/api/payments" -H "$AUTH")
check "GET /api/payments" "\[" "$PAYMENTS"

NEW_PAY=$(curl -s --max-time 10 "$BASE/api/payments" \
  -H "$AUTH" -H "Content-Type: application/json" \
  -d '{"PolicyId":1,"Amount":1200.00,"Method":"Card"}')
check "POST /api/payments" '"Amount":1200.0' "$NEW_PAY"

PAY_BY_POL=$(curl -s --max-time 10 "$BASE/api/payments?policyId=1" -H "$AUTH")
check "GET /api/payments?policyId=1" '"PolicyId":1' "$PAY_BY_POL"

echo ""

# ── 12. SECURITY / AUTH GUARD ──────────────────────────────────────────────────
echo -e "${CYAN}[12] SECURITY${NC}"

UNAUTH=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 "$BASE/api/policies")
check "GET /api/policies without token → 401" "401" "$UNAUTH"

CUST_ADMIN=$(curl -s -o /dev/null -w "%{http_code}" --max-time 10 "$BASE/api/users" \
  -H "Authorization: Bearer $CUST_TOKEN")
check "GET /api/users with customer token → 403" "403" "$CUST_ADMIN"

echo ""

# ── SUMMARY ────────────────────────────────────────────────────────────────────
echo -e "${CYAN}════════════════════════════════════════════════════════"
echo -e "  RESULTS:  ${GREEN}$PASS PASSED${NC}  |  ${RED}$FAIL FAILED${NC}"
echo -e "${CYAN}════════════════════════════════════════════════════════${NC}\n"

if [ $FAIL -eq 0 ]; then
  echo -e "${GREEN}🎉 All tests passed! Backend is fully operational.${NC}\n"
else
  echo -e "${RED}⚠️  $FAIL test(s) failed. Check output above.${NC}\n"
fi
